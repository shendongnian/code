    protected void Button1_Click(object sender, EventArgs e)
    {
    	string strLabel3 = string.Empty;
    	foreach (RepeaterItem ri in Repeater1.Items)
    	{
    		Label lbl3= (Label)ri.FindControl("Label3");
    		strLabel3 = lbl3.Text;
    	}
    	
    	//Remaing logic
    }
