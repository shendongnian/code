    private void Save()
    {
        List<string> stringRows = new List<string>();
        stringRows.Add(string.Join("|",dataGridView1.Columns.Cast<DataGridViewColumn>().Select(x => x.Name)));
    
        List<DataGridViewRow> gridViewRows = dataGridView1.Rows.Cast<DataGridViewRow>().ToList();
        gridViewRows.RemoveAt(gridViewRows.Count - 1); //Last Line is empty
    
        stringRows.AddRange(gridViewRows.Select(x => string.Join("|", x.Cells.Cast<DataGridViewCell>().Select(y => y.Value))));
        File.WriteAllLines("file.txt", stringRows);
    }
