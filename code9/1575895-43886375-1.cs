    public ObservableCollection<Rdv> Rdv
        {
            get { return _rdv; }
            set
            {
                _rdv = value;
                RaisePropertyChanged();
            }
        }
        private Rdv _selectedRdv;
        public Rdv SelectedRdv
        {
            get { return _selectedRdv; }
            set
            {
                _selectedRdv = value;
                RaisePropertyChanged();
            }
        }
        public MainViewModel()
        {
            Rdv = new ObservableCollection<Rdv>()
            {
                new Rdv("Exemple", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", new DateTime(2009, 8, 8)),
            };
            //SelectedRdv = Rdv[0];
        }
        public void AddRdv()
        {
            _rdv.Add(new Rdv() {Title = titleTextBox.Text, Subject = subjectTextBox.Text, Date = dateTextBlock.date});
        }
        public void DeleteSelectedRdv()
        {
            Rdv.Remove(SelectedRdv);
            SelectedRdv = null;
        }
    }
}
