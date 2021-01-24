    myContentControl.MouseLeftButtonDown += MyContentControl_MouseLeftButtonDown;
    private void MyContentControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        myContentControl.Focus();
        //Do what you want when the ContentControl is clicked.
    }
