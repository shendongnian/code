    List<Data> list = new List<Data>();
    
    list.Add(new Data() { ID = 1, Name = "val1" });
    list.Add(new Data() { ID = 2, Name = "val2" });
    JavaScriptSerializer json = new JavaScriptSerializer();
    
    string Serialize = json.Serialize(list);
    Response.Write(Serialize);
    List<Data> DeSerialize = json.Deserialize<List<Data>>(Serialize);
    foreach (var Data in DeSerialize)
    {
        Response.Write(Data.Name);
    }
