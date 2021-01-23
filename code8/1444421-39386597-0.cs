    private void BindGrid()
            {
                string constring = @"Data Source=.\SQL2005;Initial Catalog=Northwind;User id = sa;password=pass@123";
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
    
                                //Set AutoGenerateColumns False
                                dataGridView1.AutoGenerateColumns = false;
    
                                //Set Columns Count
                                dataGridView1.ColumnCount = 3;
    
                                //Add Columns
                                dataGridView1.Columns[0].Name = "CustomerId";
                                dataGridView1.Columns[0].HeaderText = "Customer Id";
                                dataGridView1.Columns[0].DataPropertyName = "CustomerID";
    
                                dataGridView1.Columns[1].HeaderText = "Contact Name";
                                dataGridView1.Columns[1].Name = "Name";
                                dataGridView1.Columns[1].DataPropertyName = "ContactName";
    
                                dataGridView1.Columns[2].Name = "Country";
                                dataGridView1.Columns[2].HeaderText = "Country";
                                dataGridView1.Columns[2].DataPropertyName = "Country";
                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
