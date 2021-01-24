    public enum Rank
    {
        Kingdom,
        Phylum,
        Order,
    }
    
    public class Family
    {
        public Rank Rank { get; set; }
        public Rank Child => Enum.IsDefined(typeof(Rank), Rank + 1) ? Rank +  1 : throw new ArgumentOutOfRangeException("No child rank");
        public Rank Parent => Enum.IsDefined(typeof(Rank),Rank - 1) ? Rank -  1 : throw new ArgumentOutOfRangeException("No parent rank");
    
    }
