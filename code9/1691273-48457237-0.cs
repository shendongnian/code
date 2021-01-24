    protected void btnGetSelection_Click(object sender, EventArgs e)
        { 
            string result="Selected informations：";
            if (DropDownList1.SelectedItem != null)
            {
                foreach (FineUI.ListItem item in DropDownList1.SelectedItemArray)
                {
                    result = result + item.Value;
    
                } 
                labResult.Text = result;
            }
            else
                labResult.Text = "No SelectedItem";
        }
