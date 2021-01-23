    public class Level
    {
        public string background { get; set; }
        public string description { get; set; }
        public List<Enemy> enemies { get; set; }
    }
    public class Enemy
    {
        public string name { get; set; }
        public string number { get; set; }
    }
