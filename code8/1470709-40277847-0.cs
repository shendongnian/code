     protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //System.Diagnostics.Debugger.Launch();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                Label lblparent = (Label)GridView1.Rows[i].FindControl("lblRate");
                if (lblparent.Text != "-")
                {
                    string[] a = lblparent.Text.Split('/');
                    if (a[0] != a[1])
                    {
                        lblparent.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblparent.ForeColor = System.Drawing.Color.Green;
                    }
                }
    
    
            }
        }
