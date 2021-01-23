    while (trackNoReader.Read())
    {
        flpTrackNo.Controls.Add(new Button()
        {
            Name = "btnTrackNo" + x,
            Text = trackNoReader[0] as string,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Flat,
            AutoSize = false,
            Dock = DockStyle.Top,
            Width = flpArtist.Width,
            ForeColor = ColorTranslator.FromHtml("#444444"),
            Font = new Font("Trebuchet MS", 9),
            Enabled = true,
            TextAlign = ContentAlignment.MiddleLeft,
            FlatAppearance =
            {
                BorderSize = 0
            },
        });
        
        // Adds Click event handler to last added button
        flpTrackNo.Controls[flpTrackNo.Controls.Count - 1].Click += (sender, args) =>
        {
            // Call the function to play a sound
    
            // Additionally the sender gives you the specific button as object
        };
    
        x++;
    }
