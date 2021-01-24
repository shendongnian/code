     for (i = 0; i <= dt9.Rows.Count - 1; i++)
    {
        CheckBox ch = new CheckBox();
        ch =  (CheckBox)Page.FindControl(dt9.Rows[i].ItemArray[0].ToString()); <--- ERROR
    if (ch == null)
    {
        ch.Checked = true;
        ch.Enabled = false;
        ch.BackColor = System.Drawing.Color.Chocolate;
    }
    }
