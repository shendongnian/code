    class PersoanaViewModel
    {
        private Persoana _persoana;
    
        public string Nume
        {
            get
            {
                return _persoana.Nume;
            }
            set
            {
                _persoana.Nume = value;
            }
        }
        [...]
    }
