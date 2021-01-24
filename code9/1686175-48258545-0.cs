    public class Props
    {
        public string name { get; set; }
    }
    public class Gender
    {
        public int id { get; set; }
        public Props props { get; set; }
    }
    public class Details
    {
        public Gender gender { get; set; }
    }
    public class JsonObject
    {
        public Details details { get; set; }
    }
