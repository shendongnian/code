    public static void ImportCSV(string CSV, string TableName, string ConnectionString)
    		{
    			using (MySqlConnection conn = new MySqlConnection(ConnectionString.ToString()))
    			{
    				MySqlBulkLoader Bulkloader = new MySqlBulkLoader(conn);
    
    				Bulkloader.TableName = TableName;
    				Bulkloader.FileName = CSV;
    				Bulkloader.Timeout = 0;
    				Bulkloader.NumberOfLinesToSkip = 1;
    				Bulkloader.FieldTerminator = ";";
    
    				var result = Bulkloader.Load();
    				Console.WriteLine("Imported {0} rows into the database", result);
    			}
    
    		}
