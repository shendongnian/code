        private Model.Recipe _recipe;
        public Model.Recipe Recipe
        {
            get { return _recipe; }
            set { Set(ref _recipe, value); }
        }
        
        public string MyProperty
        {
            get { return "Test " + Recipe.MyProperty; }
        }
        public MainViewModel()
        {
            PropertyChanged += MainViewModel_PropertyChanged;
            Recipe = new Model.Recipe();
        }
        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Recipe": RaisePropertyChanged("MyProperty"); break;
            }
        }
