    public static void AttachedUriPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Border border = o as Border;            
            if (border != null)
            {                
                string uri = e.NewValue as string;
                if (!String.IsNullOrEmpty(uri))
                {
                    Uri link = new Uri(uri);
                    WebBrowser newBrowser = new WebBrowser();
                    newBrowser.Navigate(link);
                    border.Child = newBrowser;
                }                
            }
        }
