     private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
      // to check if it is not Iframe
    if (e.Url.AbsolutePath != this.webBrowser.Url.AbsolutePath)
                                {
                                    // Capture 
                                    var browser = (WebBrowser)sender;
                                    browser.ClientSize = new Size(1024,768);
                                    browser.ScrollBarsEnabled = false;
                                    m_Bitmap = new Bitmap(1024,768);
                                    browser.BringToFront();
                                    browser.DrawToBitmap(m_Bitmap, browser.Bounds);
                    
                                    // Save as file? 
                                    if (m_FileName.Length > 0)
                                    {
                                        // Save 
                                        m_Bitmap.SaveJPG100(m_FileName);
                                    }
                                }
                     }
