    this.Content = new StackLayout
    {
        Children =
        {
            new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = 
                {
                    Label,
                    infoIcon,
                }
            },
            webView
        }
    }
