    class UF
    {
        public UF(int N)
        {
            this._n = N;
            Console.WriteLine(this.n);
        }
        int _n;
        private int N
        {
            get => _n;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                else
                {
                    _n = value;
                }
            }
        }
    }
