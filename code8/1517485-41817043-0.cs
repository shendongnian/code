    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        switch (e.Url.ToString())
        {
            case "home page":
            {
                // fire click
                break;
            }
            case "next page":
            {
                // handle logged in user
                break;
            }
        }
    }
