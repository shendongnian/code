        private int clickCount;
        private DateTime lastClick;
        private System.Windows.Threading.DispatcherTimer clickEventTimer;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (clickEventTimer == null || !clickEventTimer.IsEnabled)
            {
                clickCount = 1;
                lastClick = DateTime.Now;
                clickEventTimer = new System.Windows.Threading.DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
                clickEventTimer.Tick += (timer, args) =>
                {
                    if (DateTime.Now - lastClick < TimeSpan.FromSeconds(1))
                    {
                        return;
                    }
                    else
                    {
                        clickEventTimer.Stop();
                        MessageBox.Show($"Do stuff for the {clickCount.ToString()} click(s) you got.");
                    }
                };
                clickEventTimer.Start();
            }
            else
            {
                clickCount++;
                lastClick = DateTime.Now;
            }
        }
