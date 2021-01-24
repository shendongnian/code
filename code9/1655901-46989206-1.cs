    public bool Flag { get; private set; }
    public ChildForm()
    {
        InitializeComponent();
    }
    private SomeMethod()
    {
        //some code
        Flag = true;
        this.Close();
    }
