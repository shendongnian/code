    var padding = 5;
    var buttonSize = new Size(100, 60);
    for (int i = 0; i < Screen.AllScreens.Length; i++)
    {
        var screen = Screen.AllScreens[i];
        Button monitor = new Button
        {
            Name = "Monitor" + screen,
            AutoSize = true,
            Size = buttonSize,
            Location = new Point(12 + i * (buttonSize.Width + padding), 70),
            ImageAlign = ContentAlignment.MiddleCenter,
            Image = Properties.Resources.display_enabled,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            Text = screen.Bounds.Width + "x" + screen.Bounds.Height
        };
        monitorPanel.Controls.Add(monitor);
    }
