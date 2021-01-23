    public static List<string> List1= new List<string>(); 
    
    protected void Page_Init(object sender, EventArgs e)
    {
        List1= LoadData(); //one time load data from database.
    }
