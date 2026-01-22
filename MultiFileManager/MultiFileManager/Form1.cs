using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MultiFileManager
{
    public partial class Form1 : Form
    {
        BackgroundWorker worker;
        ManualResetEvent pauseEvent = new ManualResetEvent(true);

        bool isPaused = false;
        bool isMoveOperation = false;

        string currentSource = "";
        string currentTarget = "";
        string targetDirectory = "";

        Stopwatch stopwatch = new Stopwatch();

        string draggedFilePath;
        ListView targetList;

        public Form1()
        {
            InitializeComponent();
            InitWorker();

            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), listLeft);

            listLeft.AllowDrop = true;
            listRight.AllowDrop = true;

            listLeft.ItemDrag += listLeft_ItemDrag;
            listRight.DragEnter += listRight_DragEnter;
            listRight.DragDrop += listRight_DragDrop;
        }

        void InitWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        void LoadFiles(string path, ListView list)
        {
            if (!Directory.Exists(path)) return;

            list.Items.Clear();
            list.Columns.Clear();
            list.Columns.Add("Файл", 250);

            foreach (var file in Directory.GetFiles(path))
                list.Items.Add(new ListViewItem(file));

            list.Tag = path;
        }

        private void btnSelectTarget_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog d = new FolderBrowserDialog())
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    targetDirectory = d.SelectedPath;
                    LoadFiles(targetDirectory, listRight);
                    logBox.AppendText($"Выбрана папка назначения: {targetDirectory}\n");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), listLeft);
            if (!string.IsNullOrEmpty(targetDirectory))
                LoadFiles(targetDirectory, listRight);
            logBox.AppendText("Обновление списков файлов\n");
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if (isPaused) pauseEvent.Reset();
            else pauseEvent.Set();

            logBox.AppendText(isPaused ? "Операция приостановлена\n" : "Операция возобновлена\n");
        }

        void listLeft_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListViewItem item = e.Item as ListViewItem;
            if (item != null)
            {
                draggedFilePath = item.Text;
                DoDragDrop(item.Text, DragDropEffects.Move);
            }
        }

        void listRight_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
        }

        void listRight_DragDrop(object sender, DragEventArgs e)
        {
            if (string.IsNullOrEmpty(targetDirectory)) return;

            targetList = listRight;

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Копировать", null, (s, ev) => AddToQueue(draggedFilePath, false));
            menu.Items.Add("Переместить", null, (s, ev) => AddToQueue(draggedFilePath, true));
            menu.Items.Add("Отмена");

            Point p = targetList.PointToClient(new Point(e.X, e.Y));
            menu.Show(targetList, p);
        }

        void AddToQueue(string filePath, bool move)
        {
            if (!File.Exists(filePath)) return; Label task = new Label
            {
                Text = Path.GetFileName(filePath),
                Width = queuePanel.Width - 25,
                Height = 32,
                BackColor = Color.LightBlue,
                TextAlign = ContentAlignment.MiddleLeft,
                Tag = new object[] { filePath, move }
            };

            queuePanel.Controls.Add(task);
            logBox.AppendText($"{(move ? "Перемещение" : "Копирование")}: {filePath}\n");

            if (!worker.IsBusy)
                StartNext();
        }

        void StartNext()
        {
            if (queuePanel.Controls.Count == 0) return;

            Label task = queuePanel.Controls[0] as Label;
            object[] data = task.Tag as object[];

            currentSource = data[0].ToString();
            isMoveOperation = (bool)data[1];

            if (!File.Exists(currentSource))
            {
                queuePanel.Controls.RemoveAt(0);
                StartNext();
                return;
            }

            currentTarget = Path.Combine(targetDirectory, Path.GetFileName(currentSource));

            stopwatch.Restart();
            worker.RunWorkerAsync();
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (FileStream source = new FileStream(currentSource, FileMode.Open, FileAccess.Read))
            using (FileStream target = new FileStream(currentTarget, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[4096];
                long total = source.Length;
                long copied = 0;
                int read;

                while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    pauseEvent.WaitOne();
                    target.Write(buffer, 0, read);
                    copied += read;
                    int percent = (int)(copied * 100 / total);
                    worker.ReportProgress(percent);
                    Thread.Sleep(10);
                }
            }

            if (isMoveOperation && File.Exists(currentSource))
                File.Delete(currentSource);
        }

        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 0;

            if (queuePanel.Controls.Count > 0)
                queuePanel.Controls.RemoveAt(0);

            LoadFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), listLeft);
            LoadFiles(targetDirectory, listRight);

            StartNext();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(query)) return;

            FilterFiles(listLeft, query);
            FilterFiles(listRight, query);

            logBox.AppendText($"Поиск файлов по запросу: {query}\n");
        }

        void FilterFiles(ListView list, string query)
        {
            string path = list.Tag?.ToString();
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path)) return;

            list.Items.Clear();
            list.Columns.Clear();
            list.Columns.Add("Файл", 250);

            foreach (var file in Directory.GetFiles(path))
            {
                string fileName = Path.GetFileName(file);
                if (fileName.ToLower().Contains(query))
                    list.Items.Add(new ListViewItem(file));
            }
        }
    }
}