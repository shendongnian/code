    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(wUrl);
    httpWReq.Method = "GET";
    httpWReq.ContentType = "application/json";
    httpWReq.Timeout = 300000;
    HttpWebResponse httpWResp = (HttpWebResponse)httpWReq.GetResponse();
    List<CostingNegotiated> jsonResponse = null;
    try
    {
        //Get the stream of JSON
        Stream responseStream = httpWResp.GetResponseStream();
        //Deserialize the JSON stream
        using (StreamReader reader = new StreamReader(responseStream))
        {
            string r = reader.ReadToEnd();
            //Deserialize our JSON
            DataContractJsonSerializer sr = new DataContractJsonSerializer(typeof(List<CostingNegotiated>));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(r));
            jsonResponse = (List<CostingNegotiated>)sr.ReadObject(ms);
        }
    }
    //Output JSON parsing error
    catch (Exception e)
    {
        FailComponent(e.ToString());
    }
    return jsonResponse; 
