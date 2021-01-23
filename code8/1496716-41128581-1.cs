    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var newControlContent = new ContentControl
        {
            Content = new UserControl1()
        };
        ContentPresenter.Content = newControlContent;
    }
