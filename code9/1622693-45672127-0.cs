    private void mc_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        Shape clickedShape = e.OriginalSource as Shape;
        if (clickedShape != null)
        {
            mc.Children.Remove(clickedShape);
            shapes.Remove(clickedShape);
        }
    }
