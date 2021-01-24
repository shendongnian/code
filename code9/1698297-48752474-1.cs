    private void OnWebViewPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == WebView.SourceProperty.PropertyName)
        {
            URLEntry.Text = MyWebView.Source.ToString(); // May need to check this
        }
    }
