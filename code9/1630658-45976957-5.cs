    protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        TextBox2.Text = ""
        CheckBox ChkBoxHeader = (CheckBox)gvcntct.HeaderRow.FindControl("chkboxSelectAll");
        foreach (GridViewRow row in gvcntct.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkEmp");
            ChkBoxRows.Checked = ChkBoxHeader.Checked;        
        }
    }
    
    protected void chkEmp_CheckedChanged(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox CheckBox1 = (System.Web.UI.WebControls.CheckBox)sender;
        GridViewRow row = (GridViewRow)CheckBox1.NamingContainer;
        Label lblUser = (Label)row.FindControl("lblMake");
        string ID = row.Cells[2].Text;
    
        if (TextBox2.Text.Length > 0)
        {
            string[] Ids = TextBox2.Text.Split(',');
    
            if (CheckBox1.Checked == true)
            {
                TextBox2.Text += string.Format(", {0}", ID);
            }
            else if (CheckBox1.Checked == false)
            {
                CheckBox ChkBoxHeader = (CheckBox)gvcntct.HeaderRow.FindControl("chkboxSelectAll");
                foreach (GridViewRow rows in gvcntct.Rows)
                {
                    CheckBox ChkBoxRows = (CheckBox)rows.FindControl("chkEmp");
                    ChkBoxHeader.Checked = false;
                    ChkBoxRows.Checked = false;
                    TextBox2.Text = TextBox2.Text
                                       .Replace(string.Format(", {0}", ID), "")
                                       .Replace(string.Format("{0}", ID), "");
                }
            }
            else
            {
                TextBox2.Text = string.Empty;
                int index = 0;
                foreach (string s in Ids)
                {
                    if (!s.Equals(","))
                    {
                        TextBox2.Text += string.Format("{0},", Ids[index]);
                    }
    
                    index++;
                }
                if (TextBox2.Text.Contains(","))
                {
                    TextBox2.Text = TextBox2.Text.Replace(string.Format(", {0}", ID), "");
                }
            }
        }
        else
        {
            TextBox2.Text = ID;
        }
    }
