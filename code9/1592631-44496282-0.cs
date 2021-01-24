        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
                OnPropertyChanged("Rooms");
            }
        }
