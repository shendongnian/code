    public static class Program
    {
        private static NotifyIcon notifyIcon;
        [STAThread]
        public static void Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.BalloonTipTitle = "Title";
            notifyIcon.Visible = true;
            Task timerTask = Program.RunPeriodically(() => { Program.SendNotification(DateTime.Now.ToString(), ToolTipIcon.Info); }, TimeSpan.FromSeconds(10), tokenSource.Token);
            timerTask.Wait(tokenSource.Token);
        }
        private static void SendNotification(string message, ToolTipIcon balloonIcon)
        {
            notifyIcon.BalloonTipIcon = balloonIcon;
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(500);
        }
        private static async Task RunPeriodically(Action action, TimeSpan interval, CancellationToken token)
        {
            while (true)
            {
                action();
                await Task.Delay(interval, token);
            }
        }
    }
