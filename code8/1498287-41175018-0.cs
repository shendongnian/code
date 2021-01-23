    string URI = "site.com/mail.php";
    using (WebClient client = new WebClient())
    {
        System.Collections.Specialized.NameValueCollection postData = 
            new System.Collections.Specialized.NameValueCollection()
           {
                  { "to", emailTo },  
                  { "subject", currentSubject },
                  { "body", currentBody }
           };
        string pagesource = Encoding.UTF8.GetString(client.UploadValues(URI, postData));
    }
