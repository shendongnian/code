    public static void SaveUrlToFile(string uri, string filePath)
    {
        var fileReq =  HttpWebRequest.Create(uri) as HttpWebRequest;
    
        //Create a response for this request
        var fileResp = (HttpWebResponse) fileReq.GetResponse();
    
        //Get the Stream returned from the response
        using (var stream = fileResp.GetResponseStream())
        {
            using (var fileStream = File.OpenWrite(filePath))
            {
                stream.CopyTo(fileStream);
            }
        }
    }
