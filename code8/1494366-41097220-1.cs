        public void InitModel()
        {
            Model.PropertyChanged += Model_PropertyChanged;
        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RunTinting")
            { 
                OnPropertyChanged("RunTinting2");
            }
            
        }
