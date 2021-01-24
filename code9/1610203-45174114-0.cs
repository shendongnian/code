    protected void assignmentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Session["IsCompany"] == null)
        {
            Session["IsCompany"] = entityDropDown.SelectedValue == "Company";
        }
        bool? isCompany = Session["IsCompany"] as bool?;
        bool IsCompany = (bool)isCompany;
        TableCell cell;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            cell = e.Row.Cells[0];
            HyperLink link = new HyperLink();
            if (IsCompany)
            {
                link.NavigateUrl = "~/CompanyPage.aspx?Ticker=" + cell.Text;
            }
            else
            {
                link.NavigateUrl = "~/PeoplePage.aspx?PersonId=" + cell.Text;
            }
            link.Text = cell.Text;
            cell.Controls.Clear();
            cell.Controls.Add(link);
            /* with this code included, I experience problems with the SelectedIndexChanged event of the dropdown
            if (IsCompany)
            {
                e.Row.Cells.Remove(e.Row.Cells[1]);
            }
            */
            cell = e.Row.Cells[2];
            
            var dd = e.Row.FindControl("assignmentDropDown") as DropDownList;
            string assignment = ((DataRowView)e.Row.DataItem)["Assignment"].ToString();
            foreach (ListItem li in dd.Items)
            {
                if (li.Value == assignment)
                {
                    li.Selected = true;
                    break;
                }
            }
            cell = e.Row.Cells[4];
            if (cell.Text == "False")
            {
                //"completeButton"
                var cb = e.Row.FindControl("completeButton") as Button;
                cb.Enabled = false;
                cb.Visible = false;
            }
            else
            {
                ((Button)cell.FindControl("completeButton")).CommandArgument = e.Row.RowIndex.ToString();
            }
        }
    }
