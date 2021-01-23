    private Panel CreatePanel(string name, int locationY)
    {
        var panel = new Panel();
        panel.Location = new Point(0, locationY);
        panel.Name = name;
        panel.Width = 1052;
        panel.Height = 50;
        panel.BackColor = Color.FromArgb(222, 222, 222);       
        return panel;
    }
