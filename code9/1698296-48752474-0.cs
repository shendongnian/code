    public void OnWebViewPropertyChanged(string propertyName)
    {
        if (propertyName == WebView.SourceProperty.PropertyName)
        {
            URLEntry.Text = MyWebView.Source.ToString(); // May need to check this
        }
    }
