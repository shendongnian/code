    private void Login()
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44305/Token");
        request.Method = "POST";
        request.AllowAutoRedirect = false;
        request.Accept = "*/*";
        request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        StringBuilder postData = new StringBuilder();
        postData.Append("grant_type=" + HttpUtility.UrlEncode("password") + "&");
        postData.Append("username=" + HttpUtility.UrlEncode("alice@example.com") + "&");
        postData.Append("password=" + HttpUtility.UrlEncode("password"));
        using (StreamWriter stOut = new StreamWriter(request.GetRequestStream(), Encoding.UTF8))
        {
            stOut.Write(postData);
            stOut.Close();
        }
    }
