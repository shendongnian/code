    public async Task AddFileNamesAsync(string[] fileNames)
    {
        fileNames.ShouldNotBeNull();
    
        var list = fileNames.Select(f => new { value = f });
    
        using (var bulkCopy = new SqlBulkCopy(ConnectionString))
        {
            using (var reader = ObjectReader.Create(list))
            {
                bulkCopy.DestinationTableName = "FileNames";
                bulkCopy.ColumnMappings.Add("value", "FileName");
                        
                try
                {
                    await bulkCopy.WriteToServerAsync(reader)
                                    .ConfigureAwait(false);
    
                }
                catch(Exception ex)
                {
    
                }
            }
        }
    }
