    ClientContext clientContext = new ClientContext(someSharePointUrl);
    clientContext.ExecutingWebRequest += delegate (object sender, WebRequestEventArgs e)
    {
    	e.WebRequestExecutor.WebRequest.Headers["Authorization"] = string.Format("Bearer {0}", someUserToken);
    };
    //... then use clientContext as usual
