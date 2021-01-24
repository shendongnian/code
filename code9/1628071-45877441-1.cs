    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)    
    {    
        Label YourControl= (Label)e.Row.FindControl("YourControl");    
        if (YourControl != null)    
        {    
            if (YourControl.Text.Trim() == "0")    
            {    
                LinkButton YourControl= (LinkButton)e.Row.FindControl("YourControl");    
                YourControl.Visible = false;    
            }
    
        }
    
    }
