    public void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(new PageAsyncTask(LoadSomeData));
    }
 
