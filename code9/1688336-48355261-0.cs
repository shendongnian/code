    class Leden
    {
        private Lid[] _Items1 = new Lid[0];
        public Lid this[int index]
        {
            get { return _Items1[index]; }
        }
        public int Count { get; private set; }
        public void Add(Lid leden)
        {
            Count++;
            Array.Resize(ref _Items1, Count);
            _Items1[Count - 1] = leden;
        }
    }
