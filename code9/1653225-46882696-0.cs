    public static void NotifProc(string message)
    {
        p.Topmost = true;
        p.Content.Content = message;
        p.Left = SystemParameters.WorkArea.Width / 2 - (p.Width / 2);
        p.Top = 0;
        p.Show();
        var animation = new DoubleAnimation
        {
            To = -114,
            BeginTime = TimeSpan.FromSeconds(2),
            Duration = TimeSpan.FromSeconds(0.57)
        };
        animation.Completed += (s, e) => p.Hide();
        p.BeginAnimation(TopProperty, animation);
    }
