    public class MyGroupItem
    {
        public MyGroupItem(string _name, double _multiplier)
        {
            name = _name;
            multiplier = _multiplier;
        }
        protected double multiplier = 1.0;
        protected string name = "";
        public string Name
        {
            get { return name; }
        }
    }
