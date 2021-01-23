    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (e.PreviousSize != new Size())
        {
            MessageBox.Show("Window is Resized");
        }
    }
