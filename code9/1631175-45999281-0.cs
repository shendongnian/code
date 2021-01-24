    public class Card
    {
        public int Id { get; set; }
    }
    public class CheckItem
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public virtual Card Card { get; set; }
    }
