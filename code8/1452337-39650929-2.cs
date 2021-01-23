    public MainWindow()
    {
        InitializeComponent();
        ObservableCollection<Person> Persons = new ObservableCollection<Person>();
        for(int i = 0; i < 10; i++)
        {
            Person p = new Person();
            p.Id = i;
            p.Age = i + 10;
            p.Name = "Name " + i;
            p.LastName = "LastName " + i;
            Persons.Add(p);
        }
        dtgPersons.ItemsSource = Persons;
    }
