    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label Unita = (e.Row.FindControl("YourGridViewUnitaLabelID") as Label);
            string unitaName = (e.Row.FindControl("YourGridViewUnitaLabelID") as Label).Text;
            ViewState["OrigData"] = unitaName;
            if (unitaName.ToString().Length >= 20) 
            {
                unitaName = unitaName.Substring(0, 20) + "..."; 
                //20 is the length of your string, you can change it to whatever length you want.
                Unita.Text = unitaName;
                Unita.ToolTip = ViewState["OrigData"].ToString();
            }
        }
    }
