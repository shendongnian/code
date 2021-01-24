        protected void repeater_ItemCreated(object sender, RepeaterItemEventArgs e)
		{
			var drlApplicationStatus = (DropDownList)e.Item.FindControl("drlApplicationStatus");
			drlApplicationStatus.SelectedIndexChanged += drlApplicationStatus_SelectedIndexChanged;
		}
		private void drlApplicationStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			var drlApplicationStatus = (DropDownList)sender;
			Response.Write(drlApplicationStatus.SelectedValue);
			Response.Write(drlApplicationStatus.SelectedItem.Text);
		}
