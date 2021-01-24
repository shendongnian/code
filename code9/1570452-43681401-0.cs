    // Convert the row collection to a list, so that we could query it easily with Linq
    List<DataGridViewRow> mySearchList = dataGridView1.Rows.Cast<DataGridViewRow>().ToList();
    const int KEY_INDEX = 0; // Search index in the grid
    const int VALUE_INDEX = 1; // Value (replace) index in the grid
    for (int i = 0; i < arrayofLines.Length; i++)
    {
    
        string line = arrayofLines[i];
    
        // Get data grid view Row where this line contains the key string
        DataGridViewRow matchedRow = mySearchList.FirstOrDefault(obj => line.Contains(obj.Cells[KEY_INDEX].Value.ToString()));
        // If this row exists, replace the key with the value (obtained from the grid)
        if (matchedRow != null)
        {
            string key = matchedRow.Cells[KEY_INDEX].Value.ToString();
            string value = matchedRow.Cells[VALUE_INDEX].Value.ToString();
    
            line = line.Replace(key, value);
    
            sw.WriteLine(line);
        }
        else
        {
            // Otherwise, do nothing
        }
    }
