    public Form1()
    {
       InitializeComponent();
       Application.Idle += (sender, eargs) => ProcessCommands();
    }
    private void ProcessCommands()
    {
        while(true)
        {
          string latest = ThreadCommandQueue.GetInstance().Get();
          if(string.IsNullOrEmpty(latest)) return;
          OutputBox.Text += latest + "\n";
        }
    }
