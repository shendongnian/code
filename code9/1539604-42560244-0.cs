    for (int i = 0; i < lists.Count; i++)
    {
        int currentIndex = newRowsBeginAt + i;
        int newIndex = lists[i].Item2;
        if (currentIndex != newIndex)
        {
            DataRow row = dt.Rows[currentIndex];
            object[] data = row.ItemArray;  // need to clone it otherwise RemoveAt will delete data
            dt.Rows.RemoveAt(currentIndex); // remove it from the table
            row.ItemArray = data;           // needed to restore data
            dt.Rows.InsertAt(row, newIndex);// insert to correct position
        }
    }
