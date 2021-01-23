      public void Repeater(Button btn, int interval)
      {
        var timer = new Timer { Interval = interval };
        timer.Tick += (sender, e) =>  {timer.Stop();moveApp();}
        btn.MouseDown += (sender, e) => timer.Start();
        btn.MouseUp += (sender, e) => timer.Stop();
        btn.Disposed += (sender, e) =>
        {
            timer.Stop();
            timer.Dispose();
        };
      }
