    private void TextBox_ContextMenuOpening_1(object sender, ContextMenuEventArgs e)
    {
        (sender as TextBox).IsReadOnly = false;
    }
    private void TextBox_ContextMenuClosing_1(object sender, ContextMenuEventArgs e)
    {
        (sender as TextBox).IsReadOnly = true;
    }   
    private void TextBox_PreviewKeyDown_1(object sender, KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.V && Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
        {
            (sender as TextBox).IsReadOnly = false;
        }
    }
    private void TextBox_KeyDown_1(object sender, KeyEventArgs e)
    {
        (sender as TextBox).IsReadOnly = true;
    }
