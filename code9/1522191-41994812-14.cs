    protected void Page_Load(object sender, EventArgs e)
    {
    
        //RadTabStrip1.Tabs[2].Visible = false;
        RadTabStrip1.Tabs[2].Enabled = false;
    }
 
    protected void Button1_Click(object sender, EventArgs e)
        {
            RadTabStrip1.Tabs[2].Enabled = true;
        }
