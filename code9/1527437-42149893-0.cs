    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private string _ActualSizeStr;
        private double? _ActualSize;
    
        public string ActualSizeStr
        {
            get { return _ActualSizeStr; }
        }
                   
        public double? ActualSize
        {
            get { return _ActualSize; }
            set
            {
                _ActualSize = value;
                if (value.HasValue)
                {
                    _ActualSizeStr = value.Value.ToString("#,##,##");
                }
            }
        }
    
    }
