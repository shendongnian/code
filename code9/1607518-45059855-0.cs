    [Microsoft.SqlServer.Server.SqlFunction(DataAccess = DataAccessKind.Read)]
    public static SqlString POST(String POSTurl, String auth,String user, String pass, String ContentType, SqlString JSONRequest)
    {
        SqlPipe pipe = SqlContext.Pipe;
        //Create Request
        HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(POSTurl);
        myHttpWebRequest.Method = "POST";
        if (user != null)   { myHttpWebRequest.Credentials = new NetworkCredential(user, pass); }
        else if (auth!=null) { myHttpWebRequest.Headers.Add("Authorization", auth); }
        myHttpWebRequest.ContentType = ContentType;
        StreamWriter streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream());
        streamWriter.Write(JSONRequest);
        streamWriter.Flush();
        streamWriter.Close();
        // Get the response
        HttpWebResponse httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
        // Create a new read stream for the response body and read it
        StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.UTF8);
        SqlString result = streamReader.ReadToEnd();
        
        return (result);
    } 
