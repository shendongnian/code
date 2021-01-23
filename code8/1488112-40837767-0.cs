        public class Item
        {
           public string applicationName {get; set;}
           public string machineName {get;set;}
           public string OrderNumber {get; set;}
        }
    var items = JsonConvert.DeserializeObject<List<Item>>(JsonString);
    var newJsonString = JsonConvert.SerializeObject(items.Where(i => i.OrderNumber != "D46364636"));
