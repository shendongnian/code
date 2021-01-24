    var labelSize = new Size(25, 20);
    var padDistance = 2;
    for (int i = 0; i < 101; i++)
    {                
        Controls.Add(new Label
        {
            Name = $"lbl{i}",
            Text = i.ToString(),
            Size = labelSize,
            Location = new Point(i * (padDistance + labelSize.Width), 156)
        });
    }
