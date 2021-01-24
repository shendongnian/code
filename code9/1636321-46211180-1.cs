     private void button2_Click(object sender, EventArgs e)
            {
                try
                {
                    conn.ConnectionString = "Driver=SQLite3 ODBC Driver;Datasource=TestOdbc;Version = 3;New=True;Compress=True;";
                    conn.Open();
                    SQLiteCommand comm = new SQLiteCommand();
                    comm.Connection = conn;
                    comm.CommandText = "SELECT * FROM test2";
                    SQLiteDataReader created = comm.ExecuteReader();
                    MessageBox.Show("connection opened!!!");
                    while (created.Read()) // Read() returns true if there is still a result line to read
                    {
                    // Print out the content of the text field:
                    string myreader = "";
                    try
                    {
                        myreader = created[1].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    label3.Text="  "+myreader;
                }
                comm.Dispose();
                conn.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
