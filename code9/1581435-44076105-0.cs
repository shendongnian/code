    bool oneCheckBoxIsEnabled = false;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow or the footer row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //check the state of the checkbox
            //either by checking the source data for the value that would trigger the disable
            DataRowView row = e.Row.DataItem as DataRowView;
            if (Convert.ToBoolean(row["isEnabledInDB"]) == true)
            {
                oneCheckBoxIsEnabled = true;
            }
            //or the state of the checkbox with findcontrol
            CheckBox cb = e.Row.FindControl("CheckBox1") as CheckBox;
            if (cb.Enabled == true)
            {
                oneCheckBoxIsEnabled = true;
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            //use the footer row to enable or disable the button
            DeleteButton.Enabled = oneCheckBoxIsEnabled;
        }
    }
