    public class A
    {
        public int AID { get; set; }
        public string Name { get; set; }
        public int? BID { get; set; }
        public virtual B B { get; set; }
    }
    
    public class B
    {
        public int BId { get; set; }
        public string Name { get; set; }
    }
