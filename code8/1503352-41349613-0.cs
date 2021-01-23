    var timer = new System.Windows.Threading.DispatcherTimer();
    timer.Interval = TimeSpan.FromSeconds(1.0);
    timer.Tick += timer_Tick;
    timer.Start();
    ...
    void timer_Tick(object sender, EventArgs e)
    {
        sample.GetBindingExpression(TextBlock.VisibilityProperty).UpdateTarget();
    }
