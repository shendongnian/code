    class Actions
    {
        private string[] _style;
        public string[] Style 
        {
            get { return _style ?? new string[0]; }
            set { _style = value; }
        }
    }
