    String content;
    try
    {
        content = new System.Net.WebClient().DownloadString( page );
    }
    catch( WebException e )
    {
        HttpWebResponse response = (System.Net.HttpWebResponse)we.Response;
        ... examine status, get headers, etc ...
    }
