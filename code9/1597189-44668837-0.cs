    protected void Submit(object sender, EventArgs e)
    {
        string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("GetFruitName", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FruitId", int.Parse(txtFruitId.Text.Trim()));
                cmd.Parameters.Add("@FruitName", SqlDbType.VarChar, 30);
                cmd.Parameters["@FruitName"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblFruitName.Text = "Fruit Name: " + cmd.Parameters["@FruitName"].Value.ToString();
            }
        }
    }
