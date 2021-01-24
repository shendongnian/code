    readonly static TimeSpan ts = TimeSpan.FromSeconds(1); //allow printing once per (1) second
    DateTime lastKeyPress;
    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.F9 && DateTime.Now.Subtract(lastKeyPress) >= ts)
        {
            //print...
        }
        lastKeyPress = DateTime.Now;
    }
