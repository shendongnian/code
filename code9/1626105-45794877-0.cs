    private void end_Click(object sender, RoutedEventArgs e)
    {
        IDisposable disp = VisualTreeHelper.GetParent(randy) as IDisposable;
        if (disp != null)
            disp.Dispose();
        DependencyObject parent = VisualTreeHelper.GetParent(randy);
        if (parent == null)
            MessageBox.Show("No parent");
        // If randy is removed properly, this would not crash the application.
        StackPanel s = new StackPanel();
        s.Children.Add(randy);
    }
