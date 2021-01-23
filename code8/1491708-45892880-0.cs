    private string firstName;
    public string FirstName
    {
     get {return firstName;}
     set { firstName = value; OnPropertyChange("FirstName");}
    }
