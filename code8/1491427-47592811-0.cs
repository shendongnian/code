    public void CheckWebBrowser()
    {
           while (wb.IsBusy || wb.ReadyState != WebBrowserReadyState.Complete )
                {
                    Application.DoEvents();
                }
            return;
    }
