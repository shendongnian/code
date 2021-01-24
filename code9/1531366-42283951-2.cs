    public class Car
    {
        private int _year;
        private string _make;
        public string Make 
        {
            get { return _make; }
            set
            {
                _make = value;
                ValidateIfAllValuesSet();
            }
        }
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                ValidateIfAllValuesSet();
            }
        }
        private void ValidateIfAllValuesSet()
        {
            if (_year == default(int) || _make == default(string))
                return;
   
            if (_year > 2017 || _year < 1900)
                throw new Exception("Illegal year");
        }
    }
