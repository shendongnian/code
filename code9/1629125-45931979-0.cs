      string para = JsonConvert.SerializeObject(new Customer { Name = "johndoe@se7ev.com" });
        string escapedString = para.Replace("\"", "\\\"");
        string url = @"https://{yourwebappname}.scm.azurewebsites.net/api/triggeredwebjobs/{webjobsname}/run?arguments=" + escapedString;
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.Method = "POST";
        httpWebRequest.ContentLength = 0;
        //you could find the user name and password in the webjobs property
        string logininforation = "${username}:{password}";
        byte[] byt = System.Text.Encoding.UTF8.GetBytes(logininforation);
        string encode = System.Convert.ToBase64String(byt);
        httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Basic " + encode);
       HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse() ;
