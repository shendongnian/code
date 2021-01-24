        string p1  = "access_token=" + Server.UrlEncode(ourClientID + "|" + ourClientSecret);
        string p2  = "&batch=" + 
    Server.UrlEncode( " [ { \"method\": \"get\", \"relative_url\": \"" + chrisFBID + "?fields=name,picture.type(square)\" }, " +
    					" { \"method\": \"get\", \"relative_url\": \"" + johnFBID + "?fields=name,picture.type(large)\" }, " +
    					" { \"method\": \"get\", \"relative_url\": \"" + stephFBID + "?fields=name,picture.type(large)\" } ]");
        
        string responseData = "";
        try
        {
        	HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/");
        	httpRequest.Method = "POST";
        	httpRequest.ContentType = "application/x-www-form-urlencoded";
        
        	byte[] bytedata = Encoding.UTF8.GetBytes(p1 + p2);
        	httpRequest.ContentLength = bytedata.Length;
        
        	Stream requestStream = httpRequest.GetRequestStream();
        	requestStream.Write(bytedata, 0, bytedata.Length);
        	requestStream.Close();
        
        	HttpWebResponse httpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
        	Stream responseStream = httpWebResponse.GetResponseStream();
        	StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
        
        	responseData = reader.ReadToEnd();
       	
        }
        catch (Exception ex)
        { 
        	Response.Write(ex.Message.ToString() + "<br>");
        }
        
        Response.Write("<br>" + responseData + "<br><br>");
