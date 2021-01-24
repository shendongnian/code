        /// <summary>
        /// Check if a given text exists in the given DataGridView
        /// </summary>
        /// <param name="searchText"></param>
        /// <param name="dataGridView"></param>
        /// <returns>The cell in which the searchText was found</returns>
        private DataGridViewCell GetCellWhereTextExistsInGridView(string searchText, DataGridView dataGridView)
        {
            DataGridViewCell cellWhereTextIsMet = null;
            // For every row in the grid (obviously)
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // I did not test this case, but cell.Value is an object, and objects can be null
                    // So check if the cell is null before using .ToString()
                    if (cell.Value != null && searchText == cell.Value.ToString())
                    {
                        // the searchText is equals to the text in this cell.
                        cellWhereTextIsMet = cell;
                        break;
                    }
                }
            }
            return cellWhereTextIsMet;
        }
        private void button_click(object sender, EventArgs e)
        {
            DataGridViewCell cell = GetCellWhereTextExistsInGridView(textBox1.Text, myGridView);
            if (cell != null)
            {
                // Value exists in the grid
                // you can do extra stuff on the cell
                cell.Style = new DataGridViewCellStyle { ForeColor = Color.Red };
            }
            else
            {
                // Value does not exist in the grid
            }
        }
