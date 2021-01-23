        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ReferenceToYourConnectionString"].ToString()))
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Id", SqlDbType.Varchar).Value = ViewState["id"].ToString(); //Whatever your id columntype is
            cmd.CommandText = "SELECT TOP 1 workid,transcribeddata FROM Transcription WHERE workid = @id ORDER BY workid, transcribeddata DESC";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                 CKEditor1.Text = dr["transcribeddata"].ToString()
            }
        }
