      protected void ddlClientNum_SelectedIndexChanged(object sender, EventArgs e)
            {
               ddlClientName.Items.clear();
               DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(Bussiness.GetConnectionString("Default")))
                        {
                            try
                            {
                                SqlDataAdapter adapter = new SqlDataAdapter("select distinct client_name from [dbo].[customer_master] where client_number=" + ddlClientNum.SelectedItem.Text + " order by client_name", con);
                                adapter.Fill(dt);
                                ddlClientName.DataSource = dt;
                                ddlClientName.DataTextField = "client_name";
                                ddlClientName.DataValueField = "client_name";
                                ddlClientName.DataBind();
                                ddlClientName.ClearSelection();
                                //ddlClientName.SelectedValue = ddlClientName.Items.FindByText((ddlClientNum.SelectedItem.Text).ToString()).Value;
                                 //ddlClientName.SelectedValue = ddlClientName.Items.FindByText((dt.Rows[0][0]).ToString()).Value;
                                //ddlClientName.Items.FindByText((dt.Rows[0][0]).ToString()).Selected = true;
                                ddlClientName.SelectedIndex = ddlClientName.Items.IndexOf(ddlClientName.Items.FindByText((dt.Rows[0][0]).ToString()));
                     }
               }
       }
