    public class Item
    {
        public string outcome_item_id { get; set; }
        public string outcome_sport_id { get; set; }
    }
    public class JsonObject
    {
        public string outcome_id { get; set; }
        public List<Item> items { get; set; }
    }
    var data = JsonConvert.DeserializeObject<List<JsonObject>>(json);
    var outcome_ids = data.Where(x => x.outcome_id == "4").Select(x => x.outcome_id);
