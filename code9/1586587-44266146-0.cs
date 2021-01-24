    public bool isClipboardDataValid(out string _data)
    {
        bool _isValid = false;
        if (Clipboard.ContainsData(DataFormats.Text))
        {
            _data = Clipboard.GetData(DataFormats.Text);
            _isValid = true;
        }
    return _isValid;
    }
