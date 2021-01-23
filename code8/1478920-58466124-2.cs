    private void OrderColumns()
    {
        //Will happen the first time you launch the application,
        // or whenever the file is deleted.
        if (!File.Exists(ColumnOrderFileName))
            return;
        using (FileStream fs = new FileStream(ColumnOrderFileName, FileMode.Open))
        {
            IFormatter formatter = new BinaryFormatter();
            Dictionary<string, int> order = (Dictionary<string, int>)formatter.Deserialize(fs);
            //Now that the file is open, we run through columns and reorder them
            foreach (DataGridViewColumn c in MyDataGridView.Columns)
            {
                //If columns were added between two versions, we don't bother with it
                if (order.ContainsKey(c.Name))
                {
                    c.DisplayIndex = order[c.Name];
                }
            }
        }
    }
