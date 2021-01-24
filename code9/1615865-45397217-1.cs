    protected void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
            {
                div1.Style.Add(HtmlTextWriterStyle.Display, "block");
            }           
        }
