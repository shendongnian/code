    private void TextBox_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
        if (IsValid(e.Key))
        {
            MyLogic();
        }
    }
    private void TextBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
        if (IsValid(e.Key))
        {
            MyLogic();
        }
    }
    private bool IsValid(VirtualKey key)
    {
        return key != VirtualKey.Tab;
    }
    void MyLogic()
    {
        // TODO
    }
