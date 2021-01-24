    string input_data = string.Empty;
    using (connection = new SqlConnection(connection_string))
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT * FROM name_table WHERE file_name LIKE @name";
        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = "%" + filename + "%";
        cmd.Connection = connection;
        connection.Open();
        // Try to execute the command and read back the results.
        SqlDataReader reader = cmd.ExecuteReader();
        // If there is no record or the field to check for emptyness is empty
        if(!reader.Read() || string.IsNullOrEmpty(reader.GetString("SampleField"))
             input_data = AcceptFile(coda);
        else
             testing.Text = "File exists, please try another file.";
     }
     private string AcceptFile(string coda)
     {
          coda_file_upload.SaveAs(Server.MapPath("~/") + coda);
          string readText = System.IO.File.ReadAllText(Server.MapPath("~/") + coda);
          parse_CODA(readText, coda);
          testing.Text = "Success";
          return readText;
     }
