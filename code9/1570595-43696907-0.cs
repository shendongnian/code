       private void button1_Click(object sender, EventArgs e)
        {
            string almURL = @"https://url/qcbin/";
            string domain = "domain";
            string project = "project";
            CookieContainer cookieContainer = LoginAlm2(almURL, "username", "password", domain, project);
            HttpWebRequest myWebRequest1 = (HttpWebRequest)WebRequest.Create(almURL + "/rest/domains/" + domain + "/projects/" + project + "/defects/473");
            myWebRequest1.CookieContainer = cookieContainer;
            myWebRequest1.Accept = "application/json";
            WebResponse webResponse1 = myWebRequest1.GetResponse();
            StreamReader reader = new StreamReader(webResponse1.GetResponseStream());
            string res = reader.ReadToEnd();
        }
       public CookieContainer LoginAlm2(string server, string user, string password, string domain, string project)
        {
            //Creating the WebRequest with the URL and encoded authentication
            string StrServerLogin = server + "/api/authentication/sign-in";
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(StrServerLogin);
            myWebRequest.Headers[HttpRequestHeader.Authorization] = "Basic " + Base64Encode(user + ":" + password);
            WebResponse webResponse = myWebRequest.GetResponse();
            CookieContainer c = new CookieContainer();
            Uri uri = new Uri(server);
            string StrCookie = webResponse.Headers.ToString();
            string StrCookie1 = StrCookie.Substring(StrCookie.IndexOf("LWSSO_COOKIE_KEY=") + 17);
            StrCookie1 = StrCookie1.Substring(0, StrCookie1.IndexOf(";"));
            c.Add(new Cookie("LWSSO_COOKIE_KEY", StrCookie1) { Domain = uri.Host });
            //Then the QCSession cookie
            string StrCookie2 = StrCookie.Substring(StrCookie.IndexOf("QCSession=") + 10);
            StrCookie2 = StrCookie2.Substring(0, StrCookie2.IndexOf(";"));
            c.Add(new Cookie("QCSession", StrCookie2) { Domain = uri.Host });
            //Then the ALM_USER cookie
            string StrCookie3 = StrCookie.Substring(StrCookie.IndexOf("ALM_USER=") + 9);
            StrCookie3 = StrCookie3.Substring(0, StrCookie3.IndexOf(";"));
            c.Add(new Cookie("ALM_USER", StrCookie3) { Domain = uri.Host });
            //And finally the XSRF-TOKEN cookie
            string StrCookie4 = StrCookie.Substring(StrCookie.IndexOf("XSRF-TOKEN=") + 12);
            StrCookie4 = StrCookie4.Substring(0, StrCookie4.IndexOf(";"));
            c.Add(new Cookie("XSRF-TOKEN", StrCookie4) { Domain = uri.Host });
            return c;
        }
