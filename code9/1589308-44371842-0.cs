    public abstract class CsvProcessor
    {
    	private readonly IEnumerable<string> processFiles;
    	
    	public CsvProcessor(IEnumerable<string> processFiles)
    	{
    		this.processFiles = processFiles;
    	}
    	
    	protected virtual IEnumerable<string> GetAllLinesFromFile(string fileName)
    	{
    		using(var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
    		using(var reader = new StreamReader())
    		{
    			var line = String.Empty;
    			while((line = reader.ReadLine()) != null)
    			{
    				yield return line;
    			}
    		}
    	}
    	
    	protected virtual void ProcessFiles()
    	{
    		var sb1 = new StringBuilder();
    		var sb2 = new StringBuilder();
    		
    		foreach(var file in this.processFiles)
    		{
    			var fileName = Path.GetFileNameWithoutExtension(file);
    			var lines = GetAllLinesFromFile(file);
    			
    			if(fileName.StartsWith("RO_", StringComparison.InvariantCultureIgnoreCase))
    			{
    				sb1.AppendLine(lines.Take(4)); //take only the first four lines
    				sb2.AppendLine(lines.Skip(4).TakeWhile(s => !String.IsNullOrEmpty(s))); //skip the first four lines, take everything else
    			}
    			else if(fileName.StartsWith("Load_", StringComparison.InvariantCultureIgnoreCase)
    			{
    				sb2.AppendLine(lines.Skip(1).TakeWhile(s => !String.IsNullOrEmpty(s)));
    			}
    		}
    		
    		// now write your StringBuilder objects to file...
    	}
    	
    	protected virtual void WriteFile(StringBuilder sb1, StringBuilder sb2)
    	{
    		// ... etc..
    	}
    }
