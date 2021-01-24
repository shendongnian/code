        if (e.RightButton == MouseButtonState.Pressed)
            return;
        Connection.isDragging = true;
        e.Handled = true;
        Mouse.Capture((IInputElement)sender);
    }
    private void MyPin_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        if (isDragging)
        {
            Connection.isDragging = false;
            e.Handled = true;
            Mouse.Capture(null);
        }
    }
