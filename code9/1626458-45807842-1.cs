    object test = new object();
            public Form1()
            {
                InitializeComponent();
    
                Control.CheckForIllegalCrossThreadCalls = false;
    
                for (int i = 0; i < 5; i++)
                {
                    Task.Factory.StartNew(() =>
                    {
                        string str = System.DateTime.Now.ToString("fff");
                        Debug.WriteLine(str);
                        Log(str);
                    });
                }
    
            }
    
            void Log(string content)
            {
                lock (test)
                {
                    this.txtLog.Text += System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + content + "\r\n";
                    this.txtLog.Focus();
                    this.txtLog.Select(this.txtLog.TextLength, 0);
                    this.txtLog.ScrollToCaret();
                }
            }
