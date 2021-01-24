    public Register()
    {
        InitializeComponent();
        //Set your preferred colors &theme (Material Skin)
        var materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue400, Primary.Red900, Primary.Brown900, Accent.LightBlue200, TextShade.BLACK);
        //prevent Form from Resizing 
        Sizable = false;
        //UnitOfWork, not initialized here
        //_unitOfWork = unitOfWork;
    }    
    
    public Register(IUnitOfWork unitOfWork) : this() // call default constructor!
    {
      _unitOfWork = unitOfWork;
    }
