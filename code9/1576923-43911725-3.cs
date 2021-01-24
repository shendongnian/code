    public class Route
    {
        private string _color;
        private readonly ISet<string> _validColors = new HashSet<string> {"Dark red", "Light blue"};
        public string Color
        {
            get { return _color; }
            set
            {
                if (_validColors.Contains(value))
                    _color = value;
                else
                    throw new ArgumentException("Invalid color");
            }
        }
    }
