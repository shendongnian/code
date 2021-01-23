    private async void roll_in()
    {
        while (UC.Instance.Location.X < panel.Location.X)
        {
            UC.Instance.Location = new Point((UC.Instance.Location.X + 2));
            UC.Instance.Refresh();
            if (UC.Instance.Location.X > -10)
                await Task.Delay(10);
        }
    }
