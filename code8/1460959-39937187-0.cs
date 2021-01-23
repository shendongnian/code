    // Get the hash
    string addrParams = string.Format("action=authenticate&username={0}&password={1}", user, pwd;)
    string url = string.Concat(sAddress, "?", addrParams);
    
    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
    webRequest.Timeout = 3000;
    
    using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse)
    {
        if (response.StatusCode == HttpStatusCode.OK) {
    
    	    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(MyTypeJsonResponse));
    	    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
    
    	    //json parsing response
    	    MyTypeJsonResponse response = objResponse as Response;
        }
    }
    
    [DataContract]
    public class MyTypeJsonResponse
    {
        [DataMember(Name = "myProperty2")]
        public string MyProperty1 { get; set; }
    
        [DataMember(Name = "myProperty2")]
        public string MyProperty2 { get; set; }
    }
