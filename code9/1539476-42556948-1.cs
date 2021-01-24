    private void HandleScroll(Object sender, ScrollEventArgs e)
    {   
        var diff = scrollBar1.Value - e.NewValue;
    
        if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
        {
            pictureBox1.Location = new Point(diff, pictureBox1.Location.Y);
        }
        else //e.ScrollOrientation == ScrollOrientation.VerticalScroll
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X, diff);
        }
    }
