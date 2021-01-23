    private void browser_DomClick(object sender, DomMouseEventArgs e)
            {
                var browser = sender as GeckoWebBrowser;
                
                if (sender != null && e != null && e.Target != null)
                {
                    if (e.Button == GeckoMouseButton.Left)
                    {
                        HandleLeftClick(e);
                    }
                    if (e.Button == GeckoMouseButton.Middle)
                    {
                        HandleMiddleClick(e);
                    }
                    if (e.Button == GeckoMouseButton.Right)
                    {
                        HandleRightClick(e);
                    }
                }
            }
