    public class Player
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    
        public int UniverseId { get; set; }
        public Universe Universe { get; set; }
    }
    public class Universe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int PlayerId { get; set; } // I think you can do without this.
        public string Name { get; set; }
        public string Domain { get; set; }
        public List<Planet> Planets { get; set; } = new List<Planet>();
    }
