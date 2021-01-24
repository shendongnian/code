    private void cbState_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (cbState.SelectedValue.ToString() != null)
         {
             string stateName = this.cbState.GetItemText(this.cbState.SelectedItem);
             retriveCountryName(stateName);
         }
    }
    private void retriveCountryName(string stateName)
    {
        using (con = new SqlConnection(connectionString))
        {
             con.Open();
             SqlCommand cmd = new SqlCommand("sp_FindCountryName", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@stateName", stateName);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             dr = dt.NewRow();
             cbCountry.ValueMember = "countryID";
             cbCountry.DisplayMember = "countryName";
             cbCountry.DataSource = dt;
        }
    }
