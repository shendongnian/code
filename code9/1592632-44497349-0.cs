    class RoomBox : INotifyPropertyChanged
    {
        private RoomDataInteraction box;
        private DatabaseContext db;
        private ObservableCollection<Room> _Rooms;
        // Rooms BindingList Property
        public ObservableCollection<Room> Rooms
        {
            get
            {
                return _Rooms;
            }
            set
            {
                _Rooms = value;
                NotifyPropertyChanged("Rooms");
            }
        }
        // SelectedRoom Property
        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get
            {
                return _selectedRoom;
            }
            set
            {
                _selectedRoom = value;
                NotifyPropertyChanged("SelectedRoom");
            }
        }
        // RoomBox Constructor
        public RoomBox()
        {
            db = new DatabaseContext();
            box = new RoomDataInteraction(db);
            Rooms = new ObservableCollection<Room>(box.GetAllRooms());
            deleteCommand = new DelegateCommand(DeleteRoom);
            updateCommand = new DelegateCommand(UpdateRoom);
            createCommand = new DelegateCommand(CreateRoom);
        }
        // Check if Room Selected?
        public bool IsSelected()
        {
            return SelectedRoom != null;
        }
        // Implementation Of DeleteCommand Property
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        // Delete the Selected Room Method & Refresh Rooms Binding :)
        public void DeleteRoom()
        {
            if (!IsSelected())
            {
                return;
            }
            box.DeleteRoom(SelectedRoom.RoomID);
            Rooms.Delete(SelectedRoom);
        }
        // Implementation Of UpdateCommand Property
        private DelegateCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }
        // Update the Selected Room Method & Refresh Rooms Binding :)
        public void UpdateRoom()
        {
            // Check If Selected?
            if (!IsSelected())
            {
                return;
            }
            // Create View Model With Selected Room To Edit
            RoomViewModel vm = new RoomViewModel(SelectedRoom);
            // Run The Room Window And Add Selected Room To Edit & Refresh Binding
            if (vm.Run())
            {
                box.UpdateRoom(SelectedRoom);
            }
        }
        // Implementation Of CreateCommand Property
        private DelegateCommand createCommand;
        public ICommand CreateCommand
        {
            get
            {
                return createCommand;
            }
        }
        //  Create Room Method & Refresh Rooms Binding :)
        public void CreateRoom()
        {
            Room create = new Room();
            RoomViewModel vm = new RoomViewModel(create);
            // Run The Room Window To Create Room & Refresh Binding
            if (vm.Run())
            {
                box.AddRoom(create);
                Rooms.Add(create);
            }
        }
        // MVVM NotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
