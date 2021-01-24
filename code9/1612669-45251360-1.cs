    protected void Footer_ddlTaxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Value from Taxes where Id=@TaxId", con);
            DropDownList ddl_Tax = (DropDownList)TaxGV.FooterRow.FindControl("Footer_ddlTaxName");
            cmd.Parameters.AddWithValue("@TaxId", ddl_Tax.SelectedValue);
            SqlDataReader reader = cmd.ExecuteReader();
            TextBox tb_Value = (TextBox)TaxGV.FooterRow.FindControl("Footer_txtValue");
            if(reader.Read())
            {
                tb_Value.Text = Convert.ToString(reader["Value"]);
            }
        }
