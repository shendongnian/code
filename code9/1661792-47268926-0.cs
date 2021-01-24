    private void btnHome_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
            System.Diagnostics.Debug.Write("some action...");
        }
    }
