    public CustomRichEditBox()
    {
        this.DefaultStyleKey = typeof(RichEditBox);
        this.TextChanged += CustomRichEditBox_TextChanged;
    }
    
    private void CustomRichEditBox_TextChanged(object sender, RoutedEventArgs e)
    {
        string value = string.Empty;
        this.Document.GetText(Windows.UI.Text.TextGetOptions.AdjustCrlf, out value);
        if (string.IsNullOrEmpty(value))
        {
            return;
        }
        CustomText = value;
    }
