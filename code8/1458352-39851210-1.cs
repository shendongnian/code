      public MainViewModel()
        {
            _model = new Model {Name = "Prop Name" };
        
        }
        private Model _model;
        public Model Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;     
            }
        }
