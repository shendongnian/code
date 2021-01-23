    public class DeserializedResult {
        public int Id { get; set; }
        public List<string> Items { get; set; }
        //you can also choose to use a dictionary if you want to keep the key "names"
        //public List<Dictionary<string, string>> Items { get; set; }
    }
