    protected void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TestBtn.Click += TestBtn_Click;
        }           
    }
    void TestBtn_Click(object sender, EventArgs e)
    {
       //Do things here
        //Do Something()
    }
