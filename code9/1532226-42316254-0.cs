    void FillData()
                {
                    // 1
                    // Open connection
                    using (SqlCeConnection c = new SqlCeConnection(
                        Properties.Settings.Default.DataConnectionString))
                    {
                        c.Open();
                        // 2
                        // Create new DataAdapter
                        using (SqlCeDataAdapter a = new SqlCeDataAdapter(
                            "SELECT * FROM Animals", c))
                        {
                            // 3
                            // Use DataAdapter to fill DataTable
                            DataTable t = new DataTable();
                            a.Fill(t);
                            // 4
                            // Render data onto the screen
                            dataGridView1.DataSource = t;
                        }
                    }
                }
