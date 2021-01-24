    class Product
    {
        private string _name;
   
        public int Id { get; set; }
        public string Name
        {
            get { return _name; }
            set { _name = value.ToUpper(); } //Automatically "fix" it the moment you set it
        }
    }
