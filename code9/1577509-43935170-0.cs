    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //check if the querystring with the token exists
        if (context.Request.QueryString["token"] != null)
        {
            //get the old token from the querystring (and do stuff with it)
            string oldToken = context.Request.QueryString["token"];
            //check if oldToken contains a value
            if (string.IsNullOrEmpty(oldToken))
            {
                return;
            }
            //generate a new token
            string newToken = Guid.NewGuid().ToString();
            //send it to the browser
            context.Response.Write(newToken);
        }
    }
