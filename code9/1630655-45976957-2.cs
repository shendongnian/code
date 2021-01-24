    if (TextBox2.Text.Length > 0)
    {
        string[] Ids = TextBox2.Text.Split(',');
        if (CheckBox1.Checked == true)
        {
            TextBox2.Text += string.Format(", {0}", ID);
        }
        if(CheckBox1.Checked == false)
        {
            CheckBox ChkBoxHeader = (CheckBox)gvcntct.HeaderRow.FindControl("chkboxSelectAll");
            foreach (GridViewRow rows in gvcntct.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)rows.FindControl("chkEmp");
                ChkBoxHeader.Checked = false;
                ChkBoxRows.Checked = false;
                TextBox2.Text = TextBox2.Text.Replace(string.Format(", {0}", ID), "");
            }               
        }
    }
    
