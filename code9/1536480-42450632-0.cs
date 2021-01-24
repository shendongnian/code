    public delegate void NewsCallback( string dataReceived );
    public static void GetNews( NewsCallback callback )
    {
        WebBrowser page = new WebBrowser();
        string data = null;
        page.Navigate(launcherScriptAddress);
        page.DocumentCompleted += delegate {
           data = page.Document.GetElementById("news").InnerText;
           callback( data );
        };
    }
