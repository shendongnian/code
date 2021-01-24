    class Server {
        public string Name { get; set; }
        public int Error0 { get; set; }
        public int Error3 { get; set; }
        public int Error4 { get; set; }
        public int Error8 { get; set; }
        public int Error9 { get; set; }
        public List<string> CronJobErrors { get; set; } = new List<string>();
    }
