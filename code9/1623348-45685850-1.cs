    public Mainmenu(string department)
    {
        InitializeComponent();
        initializeOffice(department);
    }
    public string office;
    public void initializeOffice(string department)
    {
        if (department == "Accounting Office")
        {
            office = "Accounting";
        } else if (department == "Registrar's Office")
        {
            office = "Registrar";
        }
