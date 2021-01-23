    public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            button1.Click += new EventHandler(BarAnimation);
            button2.Click += new EventHandler(BarAnimation);
            button3.Click += new EventHandler(BarAnimation);
            button4.Click += new EventHandler(BarAnimation);
        }
...
    private void button1_Click(object sender, EventArgs e)
        {
            var Proc = new Process();
            Proc.SynchronizingObject = this;
            Proc.EnableRaisingEvents = true;
            Proc.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%windir%\system32\cleanmgr.exe");
            Proc.StartInfo.Arguments = @"/sagerun:100";
            Proc.StartInfo.Verb = "runas";
            Proc.StartInfo.CreateNoWindow = true;
            Proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Proc.Start();
            Proc.Exited += new EventHandler(ProcExited); 
