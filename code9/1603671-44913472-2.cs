    public abstract class GameEvent
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public TimeSpan Time { get; set; }
        public string Comment { get; set; }
    }
