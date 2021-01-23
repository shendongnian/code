    string datapath = @"D:\project\Gitlap\EngineerEmail\jsonlist5.json";
    Dictionary<string, string> engineers = new Dictionary<string, string>();
    List<UserData> data = new List<UserData>();
    using (StreamReader r = new StreamReader(datapath))
    {
        string json = r.ReadToEnd();
        data = JsonConvert.DeserializeObject<List<UserData>>(json);
        data.ForEach(engineer => engineers.Add(engineer.email, engineer.id.ToString()));
    }
