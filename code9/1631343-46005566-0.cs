    public class C<T>
    {
        public List<T> D { get; set; } = new List<T>();
    }
    public class C2
    {
        public IReadOnlyList<int> D { get; private set; }
        public C2()
        {
            D = new List<int>();
        }
    }
    public class C3
    {
        private List<int> _d = null;
        public List<int> D
        {
            get
            {
                return _d ?? new List<int>();
            }
        }
    }
 
