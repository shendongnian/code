        /// <summary>
        /// Called whenever changes have been made to the binded list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViews_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViews_UpdateStatusColour(sender as DataGridView);
        }
        /// <summary>
        /// Change the colour of the cells in the column whose DataPropertyName is "Status"
        /// </summary>
        /// <param name="grid"></param>
        private void DataGridViews_UpdateStatusColour(DataGridView grid)
        {
            // Get the column index
            int targetColumn = 0;
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.DataPropertyName == "Status")
                {
                    targetColumn = col.Index;
                    break;
                }
            }
            
            // Loop through every row, and colour the corresponding cell
            foreach (DataGridViewRow row in grid.Rows)
            {
                DataGridViewCell cell = row.Cells[targetColumn];
                switch (cell.Value.toString())
                {
                    case ("UPDATED"):
                        cell.Style.BackColor = System.Drawing.Color.Green;
                        cell.Style.SelectionBackColor = System.Drawing.Color.Green;
                        break;
                    case ("PENDING"):
                        cell.Style.BackColor = System.Drawing.Color.Orange;
                        cell.Style.SelectionBackColor = System.Drawing.Color.Orange;
                        break;
                    case ("MISSING"):
                        cell.Style.BackColor = System.Drawing.Color.LightSalmon;
                        cell.Style.SelectionBackColor = System.Drawing.Color.LightSalmon;
                        break;
                    case ("ERROR"):
                        cell.Style.BackColor = System.Drawing.Color.Red;
                        cell.Style.SelectionBackColor = System.Drawing.Color.Red;
                        break;
                    default:
                        break;
                }
            }
        }
