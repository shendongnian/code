        string user = "{Replace with an existing userid}";
        var GUIDUrl = "https://{URL}/d2l/guids/D2L.Guid.2.asmx";
        var AuthURL = "https://{URL}/d2l/lp/auth/login/ssoLogin.d2l";
        // Load XML file (a SOAP 1.2 request as per asmx example provided), containing key/pair values
        string filepath = HttpContext.Current.Request.MapPath("~/d2l_send.xml");
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(filepath);
        // Encode XML and post request
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(GUIDUrl);
        byte[] requestBytes = Encoding.ASCII.GetBytes(xmldoc.InnerXml);
        req.Method = "POST";
        req.ContentType = "text/xml;charset=utf-8";
        req.ContentLength = requestBytes.Length;
        Stream requestStream = req.GetRequestStream();
        requestStream.Write(requestBytes, 0, requestBytes.Length);
        requestStream.Close();
        // Get response from server
        HttpWebResponse res = (HttpWebResponse)req.GetResponse();
        StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.Default);
        string backstr = sr.ReadToEnd();
        // Load response into XML document class instance
        XmlDocument xmlResult = new XmlDocument();
        xmlResult.LoadXml(backstr);
        XmlElement root = xmlResult.DocumentElement;
        XmlNodeList GUIDNode = root.GetElementsByTagName("GenerateExpiringGuidResult");
        // Get GUID
        string innerObject = Server.HtmlEncode(GUIDNode[0].InnerXml);
        string strRedirect = AuthURL + "?guid=" + innerObject + "&userid=" + user;
        //lblResult.Text = "<a href='" + strRedirect + "'>Click here</a>"; 
        sr.Close();
        res.Close();
        
        Response.Redirect(strRedirect);
