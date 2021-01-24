    public class AnimalSizeComparer : Comparer<Animal>
    {
        private readonly IList<AnimalSize> _order;
        public AnimalSizeComparer():this(Enum.GetValues(typeof(AnimalSize)).Cast<AnimalSize>().ToArray())
        {
        }
        public AnimalSizeComparer(IList<AnimalSize> order)
        {
            _order = order;
        }
        
        public override int Compare(Animal x, Animal y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return _order.IndexOf(x.Size).CompareTo(_order.IndexOf(y.Size));
        }
    }
