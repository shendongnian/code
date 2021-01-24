    _artcileTextWeb = new UIWebView(UIScreen.MainScreen.Bounds);
    _artcileTextWeb.LoadHtmlString(text, null);
    _artcileTextWeb.ScrollView.ScrollEnabled = false;
    string result = _artcileTextWeb.EvaluateJavascript("document.body.offsetHeight;");
    int height = Convert.ToInt32(result); 
    
    _scrollView.AddConstraints(
                //xxxx
                _artcileTextWeb.Below(view1, padding),
                _artcileTextWeb.WithSameLeft(view1),
                _artcileTextWeb.WithSameRight(view3),
                _artcileTextWeb.Height().EqualTo(height),
                _artcileTextWeb.AtBottomOf(_scrollView)
            );
