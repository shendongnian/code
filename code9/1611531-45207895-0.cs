    public class Item
    {
        public int? month { get; set; }
        public int? total { get; set; }
    }
    var intList = new List<int> { 4, 12 };
    var resultList = intList.ConvertAll(r =>
    {
        if (r == 4)
        {
            return new Item { month = r };
        }
        else
        {
            return new Item { total = r };
        }
    });
    var json = JsonConvert.Serialize(intList, Formatting.None,
        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
