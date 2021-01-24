    if (coda_file_upload.HasFile)
        {
            coda = Path.GetFileName(filePath);  //gets the file name
            using (connection = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT 1 FROM name_table WHERE file_name LIKE '%"+coda+"%' ";
                cmd.Connection = connection;
                connection.Open();
                string result = Convert.ToString(cmd.ExecuteNonQuery());
                connection.Close();
                if (result != '1')
                {
                    coda_file_upload.SaveAs(Server.MapPath("~/") + coda);
                    input_data = System.IO.File.ReadAllText(Server.MapPath("~/") + coda);
                    parse_CODA(input_data, coda);
                    testing.Text = "Success";
                }
                else /* Result == 1 */
                    testing.Text = "File exists, please try another file.";
            }
