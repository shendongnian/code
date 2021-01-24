    async Task<WebViewBrush> GetWebViewBrush(Windows.UI.Xaml.Controls.WebView webView)
    {
        // resize width to content
        var _OriginalWidth = webView.Width;
        var _WidthString = await webView.InvokeScriptAsync("eval",
            new[] { "document.body.scrollWidth.toString()" });
        int _ContentWidth;
    
        if (!int.TryParse(_WidthString, out _ContentWidth))
            throw new Exception(string.Format("failure/width:{0}", _WidthString));
    
        webView.Width = _ContentWidth;
    
        // resize height to content
        var _OriginalHeight = webView.Height;
    
        var _HeightString = await webView.InvokeScriptAsync("eval",
            new[] { "document.body.scrollHeight.toString()" });
        int _ContentHeight;
    
        if (!int.TryParse(_HeightString, out _ContentHeight))
            throw new Exception(string.Format("failure/height:{0}", _HeightString));
    
        webView.Height = _ContentHeight;
    
        // create brush
        var _OriginalVisibilty = webView.Visibility;
    
        webView.Visibility = Windows.UI.Xaml.Visibility.Visible;
    
        var _Brush = new WebViewBrush
        {
            Stretch = Stretch.Uniform,
            SourceName = webView.Name
        };
      //  _Brush.SetSource(webView);
    
        _Brush.Redraw();
    
        // reset, return
        webView.Width = _OriginalWidth;
        webView.Height = _OriginalHeight;
        webView.Visibility = _OriginalVisibilty;
        return _Brush;
    }
