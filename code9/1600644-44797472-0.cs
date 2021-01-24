      private DispatcherTimer _Timer = new DispatcherTimer();
      private void StartDispatcherTimer()
            {
                _Timer = new DispatcherTimer();
                _Timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / FPS);
                _Timer.Tick += new EventHandler(OnTimerTick);
                _Timer.Start();
            }
