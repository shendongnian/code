    void Main()
    {
    	var reader = new CsvReader();
    	reader.Read(@"C:\users\clint\desktop\test.csv", 10, 5);
    	reader.GetDataAtPosition(1,1).Dump();
    	reader.GetDataAtPosition(2,2).Dump();
    	reader.GetDataAtPosition(2,2, s => s.Split('/')).Dump();
    }
    
    // Define other methods and classes here
    public class CsvReader
    {
    	private string[,] _data;
    	
    	// Take a file, and estimated col and row counts (over-inflate these if needed to ensure the file can be read)
    	public void Read(string file, int cols, int rows)
    	{
    		_data = new string[rows,cols];
    		GC.Collect(2);
    		var line = 0;
    		var col = 0;
    		using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
    		{
    			using (var reader = new StreamReader(stream))
    			{
    				while (!reader.EndOfStream)
    				{
    					var lineIn = reader.ReadLine();
    					var inQuotes = false;
    					var thisCellRaw = "";
    					foreach (var ch in lineIn.TrimStart().TrimEnd())
    					{
    						if (ch == '"')
    						{
    							if (!inQuotes)
    							{
    								inQuotes = true;
    								continue;
    							}
    							
    							inQuotes = false;
    							continue;
    						}
    
    						if (ch == ',')
    						{
    							_data[line, col] = thisCellRaw;
    							thisCellRaw = "";
    							col++;
    							continue;
    						}
    						
    						thisCellRaw += ch;
    					}
    					if (!string.IsNullOrEmpty(thisCellRaw))
    					{
    						_data[line, col] = thisCellRaw;
    					}
    					line++;
    					col = 0;
    				}
    			}
    		}
    	}
    
    	public string GetDataAtPosition(int row, int col)
    	{
    		return GetDataAtPosition<string>(row,col);
    	}
    	
    	public T GetDataAtPosition<T>(int row, int col, Func<string,T> transform = null)
    	{
    		row = row - 1;
    		col = col - 1;
    		var item = _data[row,col];
    		if (item == null) throw new KeyNotFoundException("No data at that position");
    		return (transform ?? ((s) => (T)Convert.ChangeType(item, typeof(T))))(item);
    	}
    }
