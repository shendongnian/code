    private void pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        //This is a very long string that should wrap when printing
        var s = new string('a', 2048);
        //define a rectangle for the text
        var r = new Rectangle(50, 50, 500, 500);
        //draw the text into the rectangle.  The text will
        //wrap when it reaches the edge of the rectangle
        e.Graphics.DrawString(s, Me.Font, Brushes.Black, r);
        e.HasMorePages = false;
    }
