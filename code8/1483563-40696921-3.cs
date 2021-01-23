    private async void doWorkButton_Click(object sender, EventArgs e)
    {
        // Prepare the data to be loaded into your database table.
        // Note, this could be done more efficiently.
        var dataTable = new DataTable();
        {
            dataTable.Columns.Add("Field1", typeof(int));
            var rnd = new Random();
            for (int i = 0; i < 12000000; ++i)
            {
                dataTable.Rows.Add(rnd.Next(0, 2000000));
            }
        }
        using (var connection = new SqlConnection(connectionString))
        using (var bulkCopy = new SqlBulkCopy(connection))
        {
            bulkCopy.DestinationTableName = "dbo.Table1";
            try
            {
                // This will perform a bulk insert into the table
                // mentioned above, using the data passed in as a parameter.
                await bulkCopy.WriteToServerAsync(dataTable);
            }
            catch
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
