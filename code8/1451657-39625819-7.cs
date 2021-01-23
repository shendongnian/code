        public AddPersonVM()
        {
            LoadData();
            
            AddPersonCommand = new RelayCommand<object>(AddPerson);
            CancelPersonCommand = new RelayCommand<object>(CancelPerson);
        }
