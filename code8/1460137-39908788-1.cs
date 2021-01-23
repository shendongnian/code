                        int totalRows = Convert.ToInt16(strOutput[4]);
                        int totalCols = Convert.ToInt16(strOutput[5]);
                        int itemIndex = 8;
                        
                        for (int i = 0; i < totalCols; i++)
                        { dataGridView1.Columns.Add("Col", "Col");
                        }
                        dataGridView1.Rows.Add(totalRows);
                        for (int i = 0; i < totalRows; i++) 
                        { for (int j = 0; j < totalCols; j++)
                           { dataGridView1.Rows[i].Cells[j].Value = strOutput[itemIndex];
                                 itemIndex += 2;
                            }
                DataGridViewRowCollection dgRowColllection = dataGridView1.Rows;
                DataTable dtnew = new DataTable();
                for (i = dataGridView1.Items.Count; i < 1; i--)
                {
                    DataRowView currentDataRowView = dgRowColllection[i].Row;
                    dtnew.Rows.Add(currentDataRowView.Row);
                }
                dataGridView1.DataSource = dtnew;
            }
           
            dataGridView1.Visible = true;
                        }
