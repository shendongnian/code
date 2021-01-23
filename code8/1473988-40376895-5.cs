    public MainWindow()
        {
        InitializeComponent();
        List<PersonViewModel> persons = new List<PersonViewModel>();
        persons.Add(new PersonViewModel() { Firstname = "John", Gender = Genders.female });
        persons.Add(new PersonViewModel() { Firstname = "Partyboy", Gender = Genders.male });
        persons.Add(new PersonViewModel() { Firstname = "r2d2", Gender = Genders.robot });
        persons.Add(new PersonViewModel() { Firstname = "KlausMaria", Gender = Genders.shemale });
        DataContext = persons;
    }
