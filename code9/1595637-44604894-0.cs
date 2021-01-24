    for (int i = 0; i < c.GetLength(0); i++)
    {
        for (int j = 0; j < c.GetLength(1); j++)
        {
            c[i, j] = new CheckBox
            {
                Location = new Point(i * 50, j * 50),
                AutoSize = true,
                Name = i + "-" + j.ToString(),
                Text = i + "-" + j.ToString()
            };
            Controls.Add(c[i, j]);
        }
    }
