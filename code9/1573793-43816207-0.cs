    public class Rootobject
    {
        public Content[] content { get; set; }
        public From from { get; set; }
        public Personalization[] personalizations { get; set; }
    }
    public class From
    {
        public string email { get; set; }
        public string name { get; set; }
    }
    public class Content
    {
        public string type { get; set; }
        public string value { get; set; }
    }
    public class Personalization
    {
        public string subject { get; set; }
        public To[] to { get; set; }
    }
    public class To
    {
        public string email { get; set; }
    }
