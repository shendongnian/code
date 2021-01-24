    private void AddingNewRow(object sender, AddingNewItemEventArgs e)
    {
        DictionaryRowData newRow = new DictionaryRowData();
        for (int i = 0; i < dictionaryData.Columns.Count; i++)
        {
            newRow.Cells.Add(new DictionaryCellData());
        }
    
        e.NewItem = newRow;
    }
