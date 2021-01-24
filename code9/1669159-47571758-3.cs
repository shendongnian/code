    public class WipCommesseList : List<WipCommesse>
    {
        public WipCommesseList() : base()
        {
        }
        public WipCommesseList(int capacity) : base(capacity)
        {
        }
        public WipCommesseList(IEnumerable<WipCommesse> collection) : base(collection)
        {
        }
    }
