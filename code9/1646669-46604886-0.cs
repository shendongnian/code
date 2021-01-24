    class Player
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public TimeSpan Elapsed { get; set; }
        [JsonConstructor]
        public Player(Guid id, string name, TimeSpan elapsed)
        {
            this.ID = id;
            this.Name = name;
            this.Elapsed = elapsed;
        }
        public Player(string name, TimeSpan elapsed)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            this.Elapsed = elapsed;
        }
    }
