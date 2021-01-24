    byte r = 0, g = 0, b = 0;
    public void ChangeGridColor()
    {
        Task.Run(() =>
        {
            while (true)
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    MainGrid.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
                }));
                r += 1;
                g += 1;
                b += 1;
                Thread.Sleep(1000);
            }
        });
    }
