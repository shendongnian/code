    public static void CreatePoolViaRestAPI(string baseUrl, string batchAccountName, string batchAccountKey,string jsonData)
    {
        string verb = "POST";
        string apiVersion= "2016-07-01.3.1";
        string ocpDate= DateTime.UtcNow.ToString("R");
        string contentType = "application/json; odata=minimalmetadata; charset=utf-8";
        string reqUrl = string.Format("{0}/pools?api-version={1}", baseUrl, apiVersion);
        //construct the request
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(reqUrl);
        request.Method = verb;
        //Set ContentType
        request.ContentType = contentType;
        //Set ocp-date
        request.Headers.Add("ocp-date", ocpDate);
        var buffer = Encoding.UTF8.GetBytes(jsonData);
        request.ContentLength = buffer.Length;
        #region generate the signature
        string CanonicalizedHeaders = string.Format("ocp-date:{0}", ocpDate);
        string CanonicalizedResource = string.Format("/{0}/pools\napi-version:{1}", batchAccountName, apiVersion);
        string stringToSign = string.Format("{0}\n\n\n{1}\n\n{2}\n\n\n\n\n\n\n{3}\n{4}",
            verb,
            buffer.Length,
            contentType,
            CanonicalizedHeaders, CanonicalizedResource);
        //encode the stringToSign
        string signature = EncodeSignStringForSharedKey(stringToSign, batchAccountKey);
        #endregion
        //Set Authorization header
        request.Headers.Add("Authorization", string.Format("SharedKey {0}:{1}", batchAccountName, signature));
        using (var rs = request.GetRequestStream())
        {
            rs.Write(buffer, 0, buffer.Length);
        }
        //send the request and get response
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            Console.WriteLine("Response status code:{0}", response.StatusCode);
        }
    }
