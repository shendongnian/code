    public class Tips
    {
        private List<string> _tips {get; set;}
        public Tips()
        {
            _tips = new List<string>();
            _tips.Add("example 1");
            _tips.Add("example 2");
        }
        public List<string> getTips() 
        { 
            return _tips;
        }
    }
