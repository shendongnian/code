    using (DataBaseContext dbInstance = new DataBaseContext())
    {
        Table newTable = new Table()
        {
            tableName = addTable_TableNameTextBox.Text,
            tableDescription = addTable_TableDescriptionTextBox.Text,
            tableLongDescription = addTable_TableLongDescriptionTextBox.Text
        };
        DbInstance.DbTables.Add(newTable);
        DbInstance.SaveChanges();
        // Refresh the context
        DbInstance.Entry(newTable).Reload();       
    }
