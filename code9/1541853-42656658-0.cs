    <Image ... QueryCursor="Button_QueryCursor" MouseLeave="Button_MouseLeave" />
----------
    private void Image_QueryCursor(object sender, QueryCursorEventArgs e)
    {
        Cursor = Cursors.None;
        //...
    }
    private void Image_MouseLeave(object sender, MouseEventArgs e)
    {
        Cursor = null;
    }
