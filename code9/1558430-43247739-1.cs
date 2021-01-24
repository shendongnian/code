    public class Column
    {
        public string type { get; set; }
        public bool nullable { get; set; }
        public int order { get; set; }
    }
    
    public class Model
    {
        public List<Dictionary<string, Column>> columns { get; set; }
        public List<List<string>> rows { get; set; }
    }
