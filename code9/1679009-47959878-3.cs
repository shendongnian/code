    char[] invalid = new char[] { 'a', 'b' };
    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        foreach (var item in invalid)
        {
            if (e.Text.Contains(item))
            {
                e.Handled = true;
                return;
            }
        }
    }
    private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
    {
        var text = e.DataObject.GetData(typeof(string)).ToString();
        foreach (var item in invalid)
        {
            if (text.Contains(item))
            {
                e.CancelCommand();
                return;
            }
        }
    }
