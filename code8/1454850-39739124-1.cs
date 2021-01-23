    <!-- language: c# -->
        Thread _RunYouLongTime = new Thread(delegate);
        _RunYouLongTime.Start();
        while (_RunYouLongTime.IsAlive)
        {
          System.Threading.Thread.Sleep(100);
        }
