     private void BindData()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("ItemName", Type.GetType("System.String"));
                dt.Columns.Add("Category", Type.GetType("System.String"));
                dt.Columns.Add("Rate", Type.GetType("System.String"));
                dt.Columns.Add("Qty", Type.GetType("System.String"));
                dt.Columns.Add("Total", Type.GetType("System.String"));
                for (int i = 1; i <= 10; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = 1;
                    dr["ItemName"] = "hoodie";
                    dr["Category"] = "Hoodie";
                    dr["Rate"] = 25;
                    dr["Qty"] = 4;
                    dr["Total"] = (4 * 25);
                    dt.Rows.Add(dr);
                }
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
    
          
    
            protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList ddlQty = new DropDownList();
                    ddlQty = (DropDownList)e.Item.FindControl("ddlqty");
                    HiddenField hdn = new HiddenField();
                    hdn = (HiddenField)e.Item.FindControl("hdnQty");
                    if (hdn.Value != "")
                    {
                        ddlQty.SelectedItem.Selected = false;
                        ddlQty.Items.FindByValue(hdn.Value).Selected = true;
                    }
                }
            }
