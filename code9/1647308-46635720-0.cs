    private Task MigrateAsync()
    {
        return Task.Run(()=>
        {
            for (int i = 2; i <= excelData.GetUpperBound(0); i++)
            {
                var poco = new ExpandoObject() as IDictionary<string, object>;
    
                foreach (var column in distributionColumnExcelHeaderMappings)
                {
                    if (column.ColumnIndex > 0)
                    {
                        var value = excelData[i,column.ColumnIndex]?.ToString();
    
                        poco.Add(column.DistributionColumnName.Replace(" ", ""), value);
                    }
    
                }
    
                pocos.Add(poco);
            }
    
            migrationRepository.BulkInsert(insertToTable, "Id", pocos);
        });
    }
    
    private async void btnMigrate_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "Migrating data....";
    
        await MigrateAsync();
    
        lblStatus.Text = "Migration Complete";
    }
