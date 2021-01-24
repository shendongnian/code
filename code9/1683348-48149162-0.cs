    class PackViewModel
    {
        private readonly Pack _pack;
        public PackViewModel(Pack pack)
        {
            _pack = pack;
        }
        public string Name
        {
            get { return _pack.Name; }
        }
    }
