    public void CreateDataBase(string FileNameWithPath)
    {
        List<string> cmds = new List<string>();
        if (File.Exists(_pFileNameWithPath))
        {
            TextReader tr = new StreamReader(FileNameWithPath);
            string line = "";
            string cmd = "";
            while ((line = tr.ReadLine()) != null)
            {
                if (line.Trim().ToUpper() == "GO")
                {
                    cmds.Add(cmd);
                    cmd = "";
                }
                else
                {
                    cmd += line + "\r\n";
                }
            }
            if (cmd.Length > 0)
            {
                cmds.Add(cmd);
                cmd = "";
            }
            tr.Close();
        }
        if (cmds.Count > 0)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = new SqlConnection("ConnectionString To Master");
                    command.CommandType = CommandType.Text;
                    if (command.Connection.State == System.Data.ConnectionState.Closed)
                    {
                        command.Connection.Open();
                    }
                    for (int i = 0; i < cmds.Count; i++)
                    {
                        command.CommandText = cmds[i];
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox(exp.Message);
            }
        }
    }
