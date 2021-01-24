    public ActionResult Create([Bind(Include = "Email,FirstName,LastName")] ApprovedUsers approvedUsers)
    {
       var actionName = "Index"
       object content = null;
        try
        {
            using (WebClient client = new WebClient())
            {
                token = Session.GetDataFromSession<string>("access_token");
                client.Headers.Add("authorization", "Bearer " + token);
                byte[] response = client.UploadValues(apiUrl, "POST", new NameValueCollection()
                {
                    { "Email", approvedUsers.Email },
                    { "FirstName",approvedUsers.FirstName },
                    { "LastName",approvedUsers.LastName }
                });
    
                string result = System.Text.Encoding.UTF8.GetString(response);            
            }
        }
        catch
        {
            
             content = new { error = "Email exists" });
        }
      if(content!=null)RedirectToAction(actionName, content);
      RedirectToAction(actionName);
    }
