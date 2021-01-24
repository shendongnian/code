        private Model.Recipe _recipe;
        public Model.Recipe Recipe
        {
            get { return _recipe; }
            set { if (Set(ref _recipe, value)) { Messenger.Default.Send(value, "NewRecipe"); } }
        }
        
        public string MyProperty
        {
            get { return "Test " + Recipe.MyProperty; }
        }
        public MainViewModel()
        {
            Messenger.Default.Register<Model.Recipe>(this, "NewRecipe", NewRecipe);
            Recipe = new Model.Recipe();
        }
        private void NewRecipe(Recipe obj)
        {
            RaisePropertyChanged("MyProperty");
        }
