            var ds = new DataSet();
            var customersTable = ds.Tables.Add("Customers");
            customersTable.Columns.AddRange("FirstName", "LastName", "Id", "Address");
            customersTable.Rows.Add("Bob", "Sagget", 1, "123 Mockingbird Lane");
            customersTable.Rows.Add("John", "Doe", 2, "1600 Pennsylvanie Ave");
            customersTable.Rows.Add("Jane", "Doe", 3, "100 Main St");
    foreach (DataTable table in dataSet.Tables)
    {
        foreach (DataRow row in table.Rows)
        {
            foreach (DataColumn column in table.Columns)
            {
                object item = row[column];
                // read column and item
                Console.WriteLine("item ", item );
            }
        }
    }
