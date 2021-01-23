    using Newtonsoft.Json;
    public class RootObject
    {
        public string name { get; set; }
        public string type { get; set; }
        public string id { get; set; }
    }
    private string AscMyJson(string json)
    {
        var listOb = JsonConvert.DeserializeObject<List<RootObject>>(json);
        var descListOb = listOb.OrderBy(x => x.id);
        return JsonConvert.SerializeObject(descListOb);
    }
