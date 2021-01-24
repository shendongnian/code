    protected void dtlList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                DataList1.EditItemIndex = e.Item.ItemIndex;
                bind();
            }
            else if (e.CommandName.Equals("Update"))
            {
                var dataListItem = DataList1.Items[DataList1.EditItemIndex];
                var name = ((TextBox)dataListItem.FindControl("FirstName")).Text;
                var lastName = ((TextBox)dataListItem.FindControl("FirstName")).Text;
                var footItem = ((TextBox)dataListItem.FindControl("FirstName")).Text;
                var address = ((TextBox)dataListItem.FindControl("FirstName")).Text;
                var phoneNumber = ((TextBox)dataListItem.FindControl("FirstName")).Text;
                // update operation
                // ... 
                DataList1.EditItemIndex = -1;
                bind();
            }
        }
