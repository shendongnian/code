    private void PopulateDB(DataTable dtDB)
        {
            lblDataStatus.Text = "populating master table...";
            this.Refresh();
            progressBar1.Visible = true;
            progressBar1.Value = 1;
            progressBar1.Maximum = dtDB.Rows.Count;
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\path\fname.accdb";
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                using (OleDbCommand cmd = new OleDbCommand("INSERT INTO PMADocMaster( PN, PNNewRev, PN8Digit, ECO, Mon, SupNum, URL ) VALUES (?,?,?,?,?,?,?)",conn))
                {
                    try
                    {
                        cmd.Parameters.Add("@pn");, OleDbType.VarChar);
                        cmd.Parameters.Add("@rev", OleDbType.VarChar);
                        cmd.Parameters.Add("@pn8", OleDbType.VarChar);
                        cmd.Parameters.Add("@eco", OleDbType.VarChar);
                        cmd.Parameters.Add("@mon", OleDbType.VarChar);
                        cmd.Parameters.Add("@supnum", OleDbType.VarChar);
                        cmd.Parameters.Add("@url", OleDbType.VarChar);
                        conn.Open();
                        foreach (DataRow dr in dtDB.Rows)
                        {
                            progressBar1.PerformStep();
                            cmd.Parameters["@pn"].Value = dr.Field<string>("PNFullNum");
                            cmd.Parameters["@rev"].Value = dr.Field<string>("PNNewRev");
                            cmd.Parameters["@pn8"].Value = dr.Field<string>("PN8Dig");
                            cmd.Parameters["@eco"].Value = dr.Field<string>("ECO");
                            cmd.Parameters["@mon"].Value = dr.Field<string>("Mon");
                            cmd.Parameters["@supnum"].Value = dr.Field<string>("SupNum");
                            cmd.Parameters["@url"].Value = dr.Field<string>("URL");
                            cmd.ExecuteNonQuery();
                        }
                        
                        conn.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error: " + e.Message);
                        lblDataStatus.Text = e.Message;
                        return;
                        // duplicates are happening, will check veracity of data afterwards
                    }
                    progressBar1.Visible = false;
                }
            }
        }
