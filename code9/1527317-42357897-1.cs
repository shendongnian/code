    private bool setFocus = true;
    
    private void MyText_LostFocus(object sender, RoutedEventArgs e)
    {
        if (setFocus == true)
        {
            MyText.Focus(FocusState.Programmatic);
        }
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MyButton.Focus(FocusState.Programmatic);
    }
    
    private void MyButton_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        setFocus = false;
    }
    
    private void MyButton_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        setFocus = true;
    }
