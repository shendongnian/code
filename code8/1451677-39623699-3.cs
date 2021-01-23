    protected void Grid1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = null;
            foreach(GridDataItem item in Grid1.SelectedItems)
            {
                //column name is in doub quotes
                value = item["Name"].Text;
            }
        }
