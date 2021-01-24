     public MainPage()
            {
                InitializeComponent();
                PersonsList = new PersonsObservable<Person>();
                this.DataContext = PersonsList;
    
    
                PersonsList.Add(new Person());
                PersonsList.Add(new Person());
    
            }
    
            PersonsObservable<Person> PersonsList { get; set; }
