    using (var webClient = new System.Net.WebClient())
                    {
                        var text = "";
                       
                        text = Request.Form["txtFirstName"];
                        Session["Tweet"] = Request.Form["txtFirstName"];
                        var tweet = Session["Tweet"];
        
                        if (tweet != null)
                        {
                            // do whatever you need
                            text = tweet.ToString();
                            // clear the session
                            Session.Remove("Tweet");
                        }
                        if (!IsPostBack)
                        {
                            text = Request.Form["txtFirstName"];
                        }
        
        
                        var jsonString = webClient.DownloadString(text);
