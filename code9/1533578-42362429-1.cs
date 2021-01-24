      protected void ddlClientNum_SelectedIndexChanged(object sender, EventArgs e)
            {
               DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(Bussiness.GetConnectionString("Default")))
                        {
                            try
                            {
                                SqlDataAdapter adapter = new SqlDataAdapter("select distinct client_name from [dbo].[customer_master] where client_number=" + ddlClientNum.SelectedItem.Text + " order by client_name", con);
                                adapter.Fill(dt);
                                ddlClientName.ClearSelection();
                                ddlClientName.SelectedIndex = ddlClientName.Items.IndexOf(ddlClientName.Items.FindByText((dt.Rows[0][0]).ToString()));
                     }
               }
       }
