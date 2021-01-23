    public static void GetAllText(WebBrowser webBrowser,int toPageNum)
    {
           webBrowser.Focus();
           for(int i = 0; i < toPageNum; i++)
                SendKeys.Send("{PGDN}");
    }
