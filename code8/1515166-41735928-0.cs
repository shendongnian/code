		protected void dropdown1_SelectedIndexChanged(object sender, EventArgs e)
		{
			var row = (sender as DropDownList).NamingContainer as GridViewRow; //instead of Gridview1.SelectedRow;
			string dvalue = row.Cells[1].Text; //or row.FindControl(id);
			//string price = row.Cells[3].Text;
			string price = "1400"; //get from database
			row.Cells[3].Text = price; //or row.FindControl(id);
			//Gridview1.new
		}
