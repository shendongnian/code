    protected void AddStopToList_Click(object sender, EventArgs e)
    {
        DT = (DataTable)ViewState["Stop"];
        var newRow = DT.NewRow();
        newRow["id"] = StopID.Text;
        newRow["name"] = StopName.Text;
        newRow["location"] = StopLocation.Text;
        newRow["routeId"] = RouteDropDown.SelectedItem.Value.ToString().Trim();
        DT.Rows.Add(newRow);
        ViewState["Stop"] = DT; //Save DataTable back to ViewState
    
        StopListBox.DataSource = DT;
        StopListBox.DataTextField = "id";
        StopListBox.DataValueField = "id";
        StopListBox.DataBind();
    
        StopID.Text = "";
        StopName.Text = "";
        StopLocation.Text = "";
    }
