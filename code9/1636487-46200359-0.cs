    class MainViewModel
    {
        public CompanyViewModel CompanyViewModel { get; set; }
        public MembersViewModel MembersViewModel { get; set; }
        public WeeksViewModel WeeksViewModel { get; set; }
        public ObservableCollection<Members> Members { get; set; }
    }
