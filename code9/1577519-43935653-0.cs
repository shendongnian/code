    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<string> oldValues = new List<string>();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            TextBox tbOld = GridView1.Rows[i].FindControl("TextBox1") as TextBox;
            oldValues.Add(tbOld.Text);
        }
        //rebind gridview here
        for (int i = 0; i < oldValues.Count; i++)
        {
            TextBox tbNew = GridView1.Rows[i].FindControl("TextBox1") as TextBox;
            tbNew.Text = oldValues[i];
        }
    }
