    MenuToursViewModel.PropertyChanged += OnpropertyChanged;
    
        void OnPropertyChanged(Sender s, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedTour")
            {
               MenuPartiesViewModel.Items = SelectedTour.parties;
            }
        }
