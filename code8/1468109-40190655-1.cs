    protected void Page_Load(object sender, EventArgs e)
        {
            //Request.QueryString["visible"].ToString() will be same
    
            if (Request.QueryString[0].ToString() != "1")
            {
                CheckBox1.Visible = false;
            }
            else
            {
                CheckBox1.Visible = true;
            }
        }
