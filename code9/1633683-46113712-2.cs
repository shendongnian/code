	private Control _parentControl;
    protected void Page_Load(object sender, EventArgs e)
    {
        _parentControl = this; //if using an UpdatePanel use the ID of that instead of 'this'
        DataForRepeater();
    }
    private void DataForRepeater()
    {
        //just example data to load the repeater
        var dt = new DataTable();
        dt.Columns.Add("GroupID", typeof(int));
        dt.Columns.Add("GroupName", typeof(string));
        dt.Columns.Add("GroupDescription", typeof(string));
        for (int i = 1; i <= 10; i++)
        {
            var nr = dt.NewRow();
            nr["GroupID"] = i;
            nr["GroupName"] = "SomeName" + i.ToString();
            nr["GroupDescription"] = "Description of " + i.ToString() + " item";
            dt.Rows.Add(nr);
        }
        DataRepeater.DataSource = dt;
        DataRepeater.DataBind();
    }
	
    protected void DataRepeater_ItemCommand(object sender, CommandEventArgs e)
    {
        string command = e.CommandName;
        string[] arguments = e.CommandArgument.ToString().Split('|');
        switch (command)
        {
            case ("Edit"):
                //edit operation
                IdOfItemToEditHiddenField.Value = arguments[0];
                NameTextBox.Text = arguments[1];
                ScriptManager.RegisterStartupScript(_parentControl, _parentControl.GetType(), "Modal", " DisplayEditModal()", true);
                break;
            case ("Delete"):
                //delete operation
                IdOfItemToDeleteHiddenField.Value = arguments[0];
                DeleteMessageLabel.Text = arguments[1] + "<br/>" + arguments[2];
                ScriptManager.RegisterStartupScript(_parentControl, _parentControl.GetType(), "Modal", " DisplayDeleteModal()", true);
                break;
            default:
                throw new InvalidOperationException();
        }
    }
    protected void btnSaveEdit_Click(object sender, EventArgs e)
    {
        int idToSave = int.Parse(IdOfItemToEditHiddenField.Value);
        string newName = NameTextBox.Text;
        //do something to save it
        ScriptManager.RegisterStartupScript(_parentControl, _parentControl.GetType(), "Msg", string.Format("alert('Save item {0}: {1}');", idToSave, newName), true);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int idToDelete = int.Parse(IdOfItemToDeleteHiddenField.Value);
        //do something to delete it
        ScriptManager.RegisterStartupScript(_parentControl, _parentControl.GetType(), "Msg", string.Format("alert('Delete item {0}');", idToDelete), true);
    }
