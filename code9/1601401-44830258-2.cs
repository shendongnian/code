    protected void Page_Load(object sender, EventArgs e)
    {
        //empty
    }
    public void doStuffInUserControl()
    {
        Label1.Text = "Called from parent!";
    }
