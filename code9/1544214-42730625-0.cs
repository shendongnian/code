    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public virtual Team Team { get; set; }
        public int TeamId { get; set; }
    }
