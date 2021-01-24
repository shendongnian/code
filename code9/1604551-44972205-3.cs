        protected void Checked_Changed(object sender, EventArgs e)
        {
            // gets a row from GridView 
            GridViewRow subrole_row = ((CheckBox)sender).Parent as GridViewRow;
            // get GridView 
            GridView subrole = subrole_row.Parent as GridView;
            // find the datalist in GridView 
            DataList glastrole = subrole.Rows[subrole_row.RowIndex].FindControl("glastrole") as DataList;
            glastrole.DataSource = glastrole_dt; // set your data to datalist
            glastrole.DataBind(); // bind datalist
            subrole.DataSource = subrole_dt; // set your data to gridview
            subrole.DataBind(); // bind gridview
        }
        protected void glastrole_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                GridViewRow subrole_row = ((DataList)sender).Parent as GridViewRow;
                CheckBox chk1vail = subrole_row.FindControl("chk1vail") as CheckBox;
                // find CheckBoxList in glastrole
                CheckBoxList chklastrole = e.Item.FindControl("chklastrole") as CheckBoxList;
                // find if checkbox is checked
                if (chk1vail.Checked)
                {
                    // here you can check all the CheckBoxList items
                    foreach (ListItem item in chklastrole.Items)
                    {
                        item.Selected = true;
                    }
                }
                
                // find DataList in glastrole
                DataList ecounter = e.Item.FindControl("ecounter") as DataList;
                ecounter.DataSource = ecounter_dt; // set your data to datalist
                ecounter.DataBind(); // bind datalist
            }
        }
        protected void ecounter_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                DataList glastrole = ((DataList)sender).Parent as DataList;
                DataList ecounter = glastrole.Parent as DataList;
                GridViewRow subrole_row = ecounter.Parent as GridViewRow;
                CheckBox chk1vail = subrole_row.FindControl("chk1vail") as CheckBox;
                // find CheckBoxList in glastrole
                CheckBoxList chklastrole = e.Item.FindControl("chklastrole") as CheckBoxList;
                // find if checkbox is checked
                if (chk1vail.Checked)
                {
                    // here you can check all the CheckBoxList items
                    foreach (ListItem item in chklastrole.Items)
                    {
                        item.Selected = true;
                    }
                }
            }
        }
