    using (SqlDataAdapter myadapter = new SqlDataAdapter(sqlqry, connection))
                {            
                    // fill a data table
                    var t = new DataTable();
                    myadapter.Fill(t);
                    // Bind the table to the list box
                    listBox1.DisplayMember = "NameOfColumnToBeDisplayed";
                    listBox1.ValueMember = "NameOfColumnToUseValueFrom";
                    listBox1.DataSource = t;
                }
