       foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        if(column.Name == "wanted column name")
                        {
                            for(int iRow = 0; iRow < dataGridView1.RowCount; iRow++)
                            {
                                string data = (string)dataGridView1[column.Index, iRow].Value;
                                //Do something with data
                            }
        
                        }
                        
                    }
