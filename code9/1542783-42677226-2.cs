    private void listView_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        foreach (GridViewColumn c in ((GridView)listView.View).Columns)
        {
            if (double.IsNaN(c.Width))
            {
                c.Width = c.ActualWidth;
            }
            c.Width = double.NaN;
        }
    }
