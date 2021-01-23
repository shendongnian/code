	protected void search(object sender, EventArgs e)
	{
		con.Open();
		cmd.Connection = con;
		cmd.CommandText = "SELECT * FROM Driver WHERE City = '" + JourOrigin.SelectedItem + "' ";//retrieves driver names from table
		dr = cmd.ExecuteReader();
		dr.Read();
		if(Session["city"] != null)
		{
			Session["city"] = null;
		}
		if(dr.HasRows)
		{
			Session["city"] = JourOrigin.SelectedItem.ToString();
			Response.Redirect("~/Account/FindDriver.aspx");
			NoCity.Visible = false;
		}
		else
		{
			DriversJourney.Items.Clear();
			DriversJourney.Items.Add("No Drivers in selected city, try another city");
			NoCity.Visible = true;
			NoCity.Text = "No drivers in selected city, please try another city";
		}
		con.Close();
	}
