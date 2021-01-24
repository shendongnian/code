    var array = { "first_value", "second_value", "third_value" };
    var json = JsonConvert.SerializeObject(new JsonArray
    {
        Array = array,
        Some_Field = true
    });
    
    public class JsonArray
    {
        public string[] Array { get; set; }
        public bool Some_Field { get; set; }
    }
