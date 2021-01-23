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
            p.Status = true;
            Persons.Add(p);
        }
        dtgPersons.ItemsSource = Persons;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var person = dtgPersons.SelectedItem as Person;
        MessageBox.Show(person.Name + " will be removed");
    }
