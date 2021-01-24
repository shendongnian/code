	var postData = "grant_type=" + HttpUtility.UrlEncode(grant_type);
	postData += "&partner_id=" + HttpUtility.UrlEncode(partner_id);
	postData += "&client_id=" + HttpUtility.UrlEncode(client_id);
	postData += "&client_secret=" + HttpUtility.UrlEncode(client_secret);
	var body = Encoding.ASCII.GetBytes(postData);
	httpWReq.Method = "POST";
	httpWReq.ContentType = "application/x-www-form-urlencoded";
	httpWReq.ContentLength = body.Length;
	using (var stream = httpWReq.GetRequestStream())
	{
	    stream.Write(body, 0, body.Length);
	}
    HttpWebResponse httpWResp = (HttpWebResponse)httpWReq.GetResponse(); 
    // response deserialization logic
