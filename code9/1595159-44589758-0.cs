    public Point GetImageCoordsAt(MouseButtonEventArgs e)
    {
        if (child != null && child.IsMouseOver)
        {
            return e.GetPosition(child);
        }
        return new Point(-1, -1);
    }
    
    void child_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(GetImageCoordsAt(e).ToString());
    }
