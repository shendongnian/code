    struct Index
    {
        public string value;
        public int first;
        public int last;
    }
    List<Index> indexes = new List<Index>();
    
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        Index ind = indexes.SingleOrDefault(i => i.value == row.Cells[0].Value.ToString()); // Remember to set the correct index of the column
        if (String.IsNullOrEmpty(ind.value))
        {
            ind.value = row.Cells[0].Value.ToString(); // Remember to set the correct index of the column
            ind.first = ind.last = row.Index;
            indexes.Add(ind);
        }
        else
        {
            ind.last = row.Index;
        }
    }
