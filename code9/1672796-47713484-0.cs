    var req = new RestRequest("api url"); // RestSharp.dll
    var client = new RestClient("host url");
    var response = client.ExecuteTaskAsync(req).Result.Content;
    var json =((dynamic)JsonConvert.DeserializeObject(response))
     //Newtonsoft.Json.dll
    var dic = new Dictionary<string, List<Tuple<string, string>>>();
    foreach (var item in json)
    {
      var items = new List<Tuple<string, string>>();
      foreach (var value in item.Value)
      {
           var newItem = new Tuple<string, string>(value.Name, value.Value.ToString());
           items.Add(newItem);
      }
      if (items.Any())
      {
           dic.Add(item.Name, items);
      }
    }
