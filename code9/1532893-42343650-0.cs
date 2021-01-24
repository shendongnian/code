    private string getBrand(string id)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select brand from tbl_products where productId = '" + id + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt.Rows[0][0].ToString();
        }    
