    protected void Button3_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < DetailsView2.Rows.Count; i++)
        {
            CheckBox chk1 = (CheckBox)DetailsView2.Rows[i].FindControl("CheckBox1");
            CheckBox chk2 = (CheckBox)DetailsView2.Rows[i].FindControl("CheckBox2");
            if (chk1.Checked && chk2.Checked)
            {
               // Do Stuff
            }
        }
    }
