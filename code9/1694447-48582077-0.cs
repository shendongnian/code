    string JsonRequestData="yourData.json"
    public void InsertIntoDB(string JsonRequestData){
      var json = File.ReadAllText(jsonRequestData);  
      var jsonObj = JObject.Parse(json);  
      string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,  
                               Newtonsoft.Json.Formatting.Indented);
      // Your can than save this to new SqlConnection() from here
    }
