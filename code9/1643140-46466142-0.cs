    public class MyViewModel : IDataErrorInfo
    {
        private int _min;
        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }
        private int _max;
        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }
        public string Error { get { return null; } }
        public string this[string columnName]
        {
            get
            {
                switch(columnName)
                {
                    case "Min":
                        if (_min > _max)
                            return "Min cannot be greater than Max";
                        break;
                    case "Max":
                        if (_max < _min)
                            return "Max cannot be smaller than Min";
                        break;
                }
                return null;
            }
        }
    }
