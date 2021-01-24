        <telerik:RadComboBox ID="ddlAddDepartment" runat="server" Width="250px" Height="15`enter code here`0px"
                                EmptyMessage="Select a Department" EnableLoadOnDemand="True" ShowMoreResultsBox="true"
                                EnableVirtualScrolling="true" OnItemsRequested="ddlAddDepartment_ItemsRequested">
        </telerik:RadComboBox>
    
    protected void ddlAddDepartment_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {        
            const int ItemsPerRequest = 20;
            int totalCount = Convert.ToInt32(BLL.Common.GetAutocompleteTotalCountForComboExtention("Departments", "DepartmentID", "DepartmentName", e.Text).Rows[0]["ValueCount"].ToString());
            int itemOffset = e.NumberOfItems;
            int endOffset = Math.Min(itemOffset + ItemsPerRequest, totalCount);
            e.EndOfItems = endOffset == totalCount;
            DataTable data = BLL.Common.GetAutocompleteDataForComboExtention("Departments", "DepartmentID", "DepartmentName", e.Text, itemOffset, endOffset);
            if (totalCount > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    (sender as RadComboBox).Items.Add(new RadComboBoxItem(data.Rows[i]["text"].ToString(), data.Rows[i]["value"].ToString()));
                }
            }
            e.Message = (totalCount <= 0) ? "No matches" : String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", endOffset, totalCount);
    }
