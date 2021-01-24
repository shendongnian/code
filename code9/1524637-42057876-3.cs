    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        BackgroundWorker bw = new BackgroundWorker();
        int currentLine = 0;
        ProgressBar progressBar1 = new ProgressBar();
        string[] lines;
        string resolution;
        private void btnIndir_Click(object sender, EventArgs e)
        {
            resolution = comboBox1.Text;  //360, 480, 720, 1080
            lines = txtURL.Text.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DownloadNextLine);
            bw.RunWorkerAsync();
        }
        public void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Value = 0;
            var split = lines[currentLine].Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < split.Length; i++)
            {
                IEnumerable<VideoInfo> videolar = DownloadUrlResolver.GetDownloadUrls(split[i]);
                VideoInfo video = videolar.First(p => p.VideoType == VideoType.Mp4 && p.Resolution == Convert.ToInt32(resolution));
                if (video.RequiresDecryption)
                {
                    DownloadUrlResolver.DecryptDownloadUrl(video);
                }
                VideoDownloader downloader = new VideoDownloader(video, System.IO.Path.Combine(Application.StartupPath + "\\ " + GetSafeFileName(video.Title) + '_' + video.VideoExtension));
                downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;
                downloader.Execute();
            }
        }
        private string GetSafeFileName(string title)
        {
            title.Replace("/", "").Replace(",", "").Replace("\\", "").Replace("+", "");
            return title;
        }
        void downloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            SetPbValue((int)e.ProgressPercentage);
        }
        void SetPbValue(int percent)
        {
            if (progressBar2.InvokeRequired)
                progressBar2.Invoke(new Action<int>(SetPbValue), percent);
            else
                progressBar2.Value = percent;
        }
        public void DownloadNextLine(object sender, RunWorkerCompletedEventArgs e)
        {
            currentLine++;
            if (currentLine == lines.Length)
                return;
            bw.RunWorkerAsync();
        }
    }
