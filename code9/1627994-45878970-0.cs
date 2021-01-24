    private int DrawWrapped(string text, Font f, Point location, Size maxSize, Graphics g)
    {
        // how much space is needed
        var neededRect = g.MeasureString(text, f, maxSize.Width - location.X);
        var rect = new Rectangle(location, neededRect.ToSize());
        g.DrawString(text, f, Brushes.Black, rect, StringFormat.GenericDefault);
        return (int) Math.Ceiling(neededRect.Height);
    }
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        int y = 373; // keep track of where we are on the page vertically
        using (var arial14 = new Font("Arial", 14, FontStyle.Regular))
        {
            // add the used height to where we are
            y += DrawWrapped("DEVICE INFORMATION:", arial14, new Point(286, y), e.PageBounds.Size, e.Graphics);
            y += (2 * arial14.Height); // add some white space
        }
        using (var arial15 = new Font("Arial", 15, FontStyle.Regular))
        {
            y += DrawWrapped("Device Type:" + devices.Text, arial15, new Point(50, y), e.PageBounds.Size, e.Graphics);
            if (devices.Visible == true && devices.Text == "Console") // better use && me thinks 
            {
                y += DrawWrapped("Type of Console:" + consoleTextBox.Text, arial15, new Point(50, y ), e.PageBounds.Size, e.Graphics);
            }
            if (comboBox3.Visible == true) //iphone selection box is visible then show selected model on print document
            {
                y += DrawWrapped("Type of Phone:" + comboBox3.Text, arial15, new Point(50, y ), e.PageBounds.Size, e.Graphics);
                y += DrawWrapped("Service Type:" + serviceDesc.Text, arial15,  new Point(50, y ), e.PageBounds.Size, e.Graphics);
                y += DrawWrapped("Description:" + description4Repair.Text, arial15, new Point(50, y), e.PageBounds.Size, e.Graphics);
            }
        }
    }
