     ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                            grdview.DataSource = ds;
                            grdview.DataBind();
                            int columncount = grdview.Rows[0].Cells.Count;
                            grdview.Rows[0].Cells.Clear();
                            grdview.Rows[0].Cells.Add(new TableCell());
                            grdview.Rows[0].Cells[0].ColumnSpan = columncount;
                            grdview.Rows[0].Cells[0].Text = "No Records Found";
     if (e.CommandName == "AddNew")
            {
                TextBox ftxtempname = (TextBox)grdview.FooterRow.FindControl("ftxtempname");
                TextBox ftxtempno = (TextBox)grdview.FooterRow.FindControl("ftxtempno");
                TextBox ftxtempemail = (TextBox)grdview.FooterRow.FindControl("ftxtempemail");
                TextBox ftxtempage = (TextBox)grdview.FooterRow.FindControl("ftxtempage");
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("usp_add_upd_emptb", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpName", ftxtempname.Text);
                    cmd.Parameters.AddWithValue("@EmpNo", ftxtempno.Text);
                    cmd.Parameters.AddWithValue("@Desig", ftxtempage.Text);
                    cmd.Parameters.AddWithValue("@Email", ftxtempemail.Text);
    
                    con.Open();
                     cmd.ExecuteNonQuery();
    }
