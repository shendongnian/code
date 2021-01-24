    private void Button_Click(object sender, TappedRoutedEventArgs e)
    {
        MyCommandBar.IsOpen = true;
    }
    
    private void MyCommandBar_Opening(object sender, object e)
    {
        FrameworkElement senderElement = MyText as FrameworkElement;
        MyBtnFly.ShowAt(senderElement);
    }
