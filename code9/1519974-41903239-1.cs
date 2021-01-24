    protected void Page_Load(object sender, EventArgs e)
    {
        if (ScriptManager.GetCurrent(this.Page).IsInAsyncPostBack)
        {
            //updatepanel page load
        }
        else
        {
            //normal page load
        }
    }
