             if (dataGridView4.Rows.Count == 0)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            // Column headers
            string columnsHeader = "";
            for (int i = 0; i < dataGridView4.Columns.Count; i++)
            {
                columnsHeader += dataGridView4.Columns[i].Name + ",";
               
            }
            sb.Append(columnsHeader + Environment.NewLine);
            // Go through each cell in the datagridview
            foreach (DataGridViewRow dataGridView4Row in dataGridView4.Rows)
            {
                foreach (DataGridViewRow dataGridView3Row in dataGridView3.Rows)
                {
                    // Make sure it's not an empty row.
                    if (!dataGridView4Row.IsNewRow)
                    {
                        for (int c = 0; c < dataGridView4Row.Cells.Count; c++)
                        {
                            sb.Append(dataGridView4Row.Cells[c].Value + ",");
                        }
                    }
                  
                        // Add a new line in the text file.
                        sb.Append(Environment.NewLine);
                    
                }
            }
            // Load up the save file dialog with the default option as saving as a .csv file.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // If they've selected a save location...
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
                {
                    // Write the stringbuilder text to the the file.
                    sw.WriteLine(sb.ToString());
                }
            }
            // Confirm to the user it has been completed.
            MessageBox.Show("CSV file saved.");
