    void Main()
    {
    	var file = File.ReadLines(@"C:\TreeParser.txt");
    
    	var regex = new Regex(@"Level : '(?<Level>[0-9])', Row : '(?<Row>[0-9])', Col : '(?<Col>[0-9])'");
    	var records = new List<Record>();
    	
    	foreach (var line in file)
    	{
    		var matches = regex.Match(line);
    		
    		if (!matches.Success)
    		{
    			// No match was found
    			continue;
    		}
    		
    		var level = new Record
    		{
    			Level = int.Parse(matches.Groups["Level"].Value),
    			Row = int.Parse(matches.Groups["Row"].Value),
    			Col = int.Parse(matches.Groups["Col"].Value)
    		};
    		
    		records.Add(level);
    	}
    	
    	// records now contains a full list from the file
    }
    
    public class Record
    {
    	public int Level { get; set; }
    	public int Row { get; set; }
    	public int Col { get; set; }
    }
