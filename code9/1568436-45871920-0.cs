    public partial class NotifyWindow : Window
    {
      StreamWriter _stream;
      volatile int _running = 0;
      public NotifyWindow()
      {
        InitializeComponent();
        _stream = File.AppendText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"));
        WriteLine("startup");
      }
      private void WriteLine(string line)
      {
        var text = string.Format("{0}    {1}", DateTime.Now, line);
        lock (_stream)
        {
          _stream.WriteLine(text);
          _stream.Flush();
        }
      }
      private void CloseMe()
      {
        WriteLine(string.Format("CloseMe started"));
        Thread.Sleep(1000);
        WriteLine(string.Format("release lock"));
        _running = 1;
        WriteLine(string.Format("CloseMe finished"));
      }
      protected override void OnClosing(CancelEventArgs e)
      {
        WriteLine(string.Format("OnClosing started"));
        base.OnClosing(e);
        var t = new Thread(CloseMe);
        t.Start();
        WriteLine("Waiting on lock.");
      
        while(_running == 0)
        {
          Thread.Sleep(50);
          WriteLine("Waiting for 50ms.");
        }
        WriteLine("Waiting on lock finished.");
        WriteLine(string.Format("OnClosing finished"));
      }
    }
