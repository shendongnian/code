    // populate the DataTable using adapter
     SqlDataAdapter adapter = new SqlDataAdapter();
     adapter.SelectCommand = new SqlCommand("SELECT TOP 1000 [Id] ,[Name]  FROM [SomeBase]", connection);
     adapter.Fill(dataset);
    // Call the method whenever you need Slice
    // Which will give you a List<DataRow>
    public List<DataRow> GetMySlice(DataTable inputDataTable, int minSlice, int maxSlice)
    {
        return inputDataTable.AsEnumerable()
                             .Skip(minSlice)
                             .Take(maxSlice)
                             .ToList();
    }
