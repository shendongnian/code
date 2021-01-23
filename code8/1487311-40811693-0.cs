    protected void Button1_Click(object sender, EventArgs e)
    {
        List<string> ListItems = new List<string>();
    
        foreach (ListViewDataItem item in consignements.Items)
        {
            CheckBox checkBox = item.FindControl("chk") as CheckBox;
            Label label = item.FindControl("Label1") as Label;
    
            if (checkBox.Checked == true)
            {
                ListItems.Add(label.Text);
            }
        }
    }
