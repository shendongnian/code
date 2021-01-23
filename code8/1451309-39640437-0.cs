    string connStr = "Server=" + Globals.server + ";Port=" + Globals.port + "; Database=" + Globals.db + ";User Id=" + Globals.user + ";Password=" + Globals.passwd + ";";
    NpgsqlConnection conn = new NpgsqlConnection(connStr);
    conn.Open();
    NpgsqlCommand nda = new NpgsqlCommand("select name,ip_address,location from public.\"smartq_devices\"", conn);
    using (StreamReader sr = File.OpenText(Globals.sFilename))
    {
        string[] lines = File.ReadAllLines(Globals.sFilename);
        for (int x = 0; x < lines.Length - 1; x++)
        {
            NpgsqlDataReader myReader = nda.ExecuteReader();
            while (myReader.Read())
            {
                if (lines[x].Contains(myReader["name"].ToString()))
                {   
                    //MessageBox.Show(lines[x]);
                    DataRow newRow = dtResult1.NewRow();
                    newRow["Hostname"] = myReader["name"].ToString();
                    newRow["Ip address"] = myReader["ip_address"].ToString();
                    newRow["Location"] = myReader["location"].ToString();
                    if (newRow["Hostname"].ToString() != "")
                    {
                        dtResult1.Rows.Add(newRow);
     	            }
                }
            }
        }
        dgViewDevices.ItemsSource = dtResult1.AsDataView();
    }
