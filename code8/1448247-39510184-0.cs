     webview.Navigating += (s, e) =>
                {
                    if (e.Url.StartsWith("http"))
                    {
                        try
                        {
                            var uri = new Uri(e.Url);
                            Device.OpenUri(uri);
                        }
                        catch (Exception)
                        {
                        }
    
                        e.Cancel = true;
                    }
                };
