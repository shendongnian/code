    var webClient = new WebClient();
    
    string s = webClient.DownloadString(
        @"http://suggestqueries.google.com/complete/search?client=firefox&ds=yt&q="
        + "ירושלים");
    
    // s.Dump("raw"); // LinqPad dump
    
    var words = new List<string>();  // collect all words
    
    // make JObject's out of the string 
    var json = JsonConvert.DeserializeObject(s);
    // we got an Array, let's process that
    foreach(var item in (JArray)json)
    {
       // single value
       if (item is JValue)
       {
           words.Add((string)item);  // add it
       }
       else if (item is JArray) // another array
       {
          foreach(var seconditem in item)
          {
              words.Add((string)seconditem);  // add it
          }
       }
    }
