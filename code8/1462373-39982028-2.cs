    public ObservableCollection<ContactModel> Contacts { get; set; }
        public MainViewModel()
        {
            _model = new Model {Name = "Prop Name" };
            Contacts = new ObservableCollection<ContactModel>
            {
                new ContactModel {Id = 1, Name = "John Doe", Phone = "+166666333"},
                new ContactModel {Id = 2, Name = "Some Guy", Phone = "+123456789"}
            };
            SelectedContact = Contacts[0];
        }
        private ContactModel _SelectedContact;
        public ContactModel SelectedContact
        {
            get { return _SelectedContact; }
            set
            {
                _SelectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }
     
