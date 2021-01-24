    using (connection = new SqlConnection(connection_string))
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT * FROM name_table WHERE file_name LIKE @name";
        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = "%" + filename + "%";
        cmd.Connection = connection;
        connection.Open();
        SqlDataReader reader = cmd.ExecuteNonQuery();
        if(reader.Read())
        {
            string sample = reader.GetString("SampleField");
            if (string.IsNullOrEmpty(sample))
            {
                coda_file_upload.SaveAs(Server.MapPath("~/") + coda);
                input_data = System.IO.File.ReadAllText(Server.MapPath("~/") + coda);
                 parse_CODA(input_data, coda);
                testing.Text = "Success";
            }
            else
                testing.Text = "File exists, please try another file.";
        }
     }
