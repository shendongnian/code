     protected void Page_Load(object sender, EventArgs e)
        {
           if( (ContentPlaceHolder)Master.FindControl("master_login-content")!=null)
                MessageBox.Show("master");
            if (((ContentPlaceHolder)Master.FindControl("master_navigation_hori").FindControl("master_login-content"))!=null)
                MessageBox.Show("combi");
            MessageBox.Show("end");
    
        }
    
