        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ReferenceToYourConnectionString"].ToString()))
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = int.Parse(ViewState["id"].ToString()); //Whatever your id columntype is
            cmd.CommandText = "SELECT TOP 1 id,name FROM demo WHERE id = @id ORDER BY id, name DESC";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                 CKEditor1.Text = dr["name"].ToString()
            }
        }
