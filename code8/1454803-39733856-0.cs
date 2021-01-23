    string auth = string.Format("{0}:{1}", userName, password);
    string enc = Convert.ToBase64String(Encoding.ASCII.GetBytes(auth));
    string cred = string.Format("{0} {1}", "Basic", enc);
    reqest.Headers[HttpRequestHeader.Authorization] = cred;
     
