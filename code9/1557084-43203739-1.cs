    int columns = 10;
    int[] maxes = new int[columns];
    
    for (int i = 0; i < maxes.Length; i++)
    {
        int temp;
        maxes[i] = dataGridView3.Rows
                                .Cast<DataGridViewRow>()
                                .Max(r => int.TryParse(r.Cells[i].Value.ToString(), out temp) 
                                          ? temp 
                                          : int.MinValue);
    }
