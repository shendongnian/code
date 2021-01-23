    public PersonDetails()
    {
        InitializeComponent();
    }
    private void PersonDetails_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        //  ...so we can give the Grid a different DataContext
        OuterGrid.DataContext = new PersonDetailsViewModel { 
            Person = (Person)this.DataContext
        };
    }
