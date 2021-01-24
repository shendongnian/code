     protected void radcmbItemNumber_TextChanged(object sender, EventArgs e)
            {
                string textToSearch = radcmbItemNumber.Text.ToString();
                var gridItemList = radcmbItemNumber.Items[0].FindControl("radGridItemList") as RadGrid;
                if (!string.IsNullOrEmpty(textToSearch))
                    gridItemList.MasterTableView.FilterExpression = "([ItemNumber] LIKE \'%" + textToSearch + "%\')";
                
                gridItemList.MasterTableView.Rebind();
    }
