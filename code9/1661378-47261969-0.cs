     private void OnNavigationStaring(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if(!workingProgressRing.IsActive && (workingProgressRing.Visibility != Visibility.Visible)){
                this.ShowHideUiControls(true);
            }
            if (!args.Uri.ToString().Contains("yourcheck"))
            {
                args.Cancel = true;
                string url_new = args.Uri.ToString() + "&" + myDetails[0] + "&" + myDetails[1] + "&" + myDetails[2];
                   
                webView.Navigate(new Uri(url_new, UriKind.Absolute));
            }
            Debug.WriteLine("Navigation Starting",args.Uri.ToString());
        }
