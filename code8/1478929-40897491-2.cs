    public class TestClass
    {
        
        private string _d3;
        
        [System.ComponentModel.DataAnnotations.RangeAttribute(typeof(decimal), "-922337203685477.5808", "922337203685477.5807", ErrorMessage="")]
        public string d3
        {
            get
            {
                return _d3;
            }
            set
            {
                _d3 = value;
            }
        }
    }
