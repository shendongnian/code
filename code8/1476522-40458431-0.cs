            SqlCommand cmd = new SqlCommand("viewByCat]", connectionstring);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@keywords", SqlDbType.NVarChar).Value ="Your Selected value from combo box";
       
            cnn.Open();
            DataTable dt = new DataTable();
            using (SqlDataAdapter sdadptr = new SqlDataAdapter(cmd))
            {
                sdadptr.Fill(dt);
            }
            cnn.Close();
            return dt;
