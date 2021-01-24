    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Property_Name;
            Property_Name = GridView1.SelectedRow.Cells[4].Text;
            Session["Property_Name"] = Property_Name;
            //you don't need this as you already set session above
    		//CreateSurvey CS = new CreateSurvey();
            //CS.PropDetails();
            Response.Redirect("CreateSurvey.aspx");
        }
