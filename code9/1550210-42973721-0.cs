    private void filladd(int p)
    {
        DataTable dt = new DataTable();
        dt = b.get_subpaf(p);//MJ SP CHANGE
        if (dt.Rows.Count > 0)
        {
            
            DataExtensionList.DataSource = dt;
            DataExtensionList.DataBind();
            foreach (GridViewRow it1 in DataExtensionList.Rows)
            {
                CheckBox chk = (CheckBox)it1.FindControl("chkcata");
                CheckBox chk1 = (CheckBox)it1.FindControl("chkport");
                CheckBox chk2 = (CheckBox)it1.FindControl("chkwhilepages");
                if (chk.Text == "True")
                {
                    chk.Checked = true;
                }
                if (chk1.Text == "True")
                {
                    chk1.Checked = true;
                }
                if (chk2.Text == "True")
                {
                    chk2.Checked = true;
                }
            }
         }
    }
