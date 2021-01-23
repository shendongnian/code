    JObject obj = JObject.Parse(jsonString); // gets processed json object
    DataItem item = new DataItem(); 
    item.UserId = obj.SelectToken("UserId").Value<string>();
    //.. fill rest of the data
    for(int i = 0; i < item.Data.Length; i++) // iterate through all Data[x]
    {
        item.Data[i] = obj.SelectToken("Data" + i.ToString()).Value<string>();
    }
