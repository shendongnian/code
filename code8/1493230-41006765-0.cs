    public PersonViewModel(Person person) // this approach works
    {
        // Person = person ?? new Person();
        // The following 2 lines provide DesignTime data
        SetValue("FirstName", "Joe");
        SetValue("LastName", "Dalton");
        GenerateData = new Command<object, object>(OnGenerateDataExecute, OnGenerateDataCanExecute);
        ToggleCustomError = new Command<object>(OnToggleCustomErrorExecute);
    }
    public PersonViewModel(Person person) // this approach does not work
    {
        // Person = person ?? new Person();
        Person = new Person() { FirstName = "Joe", LastName = "Dalton" };
        GenerateData = new Command<object, object>(OnGenerateDataExecute, OnGenerateDataCanExecute);
        ToggleCustomError = new Command<object>(OnToggleCustomErrorExecute);
    }
