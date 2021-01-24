    var nameValueCollection = 
    System.Web.HttpUtility.ParseQueryString(Request.InputStream);
    var dictionary = nameValueCollection.AllKeys.ToDictionary(k => k, k => 
    nameValueCollection[k]);
    string json = Newtonsoft.Json.JsonConvert.SerializeObject(dictionary);
