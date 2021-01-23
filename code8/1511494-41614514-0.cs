    public class tips
    {
        public tips()
        {
            _tips = new List<string>();
    
            _tips.Add("example 1");
            _tips.Add("example 2");
        }
    
        private List<string> _tips;
        public List<string> getTips { get { return _tips; } set { _tips = value; } }
    }
