    public PersonDetails()
    {
        InitializeComponent();
        //  ...so we can give the Grid a different DataContext
        OuterGrid.DataContext = new PersonDetailsViewModel { 
            Person = (Person)this.DataContext
        };
    }
