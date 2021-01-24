    public class Car
    {
        private int _year;
        public int Year
        {
            get { return _year; }
            set
            {
                if (_year > 2017 || _year < 1900)
                    throw new Exception("Illegal year");
                _year = value;
            }
        }
    }
