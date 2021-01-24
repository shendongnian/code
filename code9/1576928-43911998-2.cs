    class Route
    {
        private string _color;
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                switch (value)
                {
                    case "First Valid Value":
                    case "Second Valid Value":
                        _color = value;
                        break;
                    default:
                        throw new ArgumentException("Invalid Value specified");
                }
            }
        }
    }
