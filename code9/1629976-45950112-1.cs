    void Main()
    {
    	var file = File.ReadLines(@"C:\TreeParser.txt");
    
    	var groupRegex = new Regex(@"Chromosome : (?<Chromosome>[0-9])");
    	var recordRegex = new Regex(@"Level : '(?<Level>[0-9])', Row : '(?<Row>[0-9])', Col : '(?<Col>[0-9])'");
    	
    	var groups = new List<Group>();
    	
    	foreach (var line in file)
    	{
    		var groupMatch = groupRegex.Match(line);
    		if (groupMatch.Success)
    		{
    			groups.Add(new Group
    			{
    				Chromosome = int.Parse(groupMatch.Groups["Chromosome"].Value),
    				Records = new List<Record>()
    			});
    		}
    		
    		var recordMatch = recordRegex.Match(line);
    		if (!recordMatch.Success)
    		{
    			// No match was found
    			continue;
    		}
    		
    		var level = new Record
    		{
    			Level = int.Parse(recordMatch.Groups["Level"].Value),
    			Row = int.Parse(recordMatch.Groups["Row"].Value),
    			Col = int.Parse(recordMatch.Groups["Col"].Value)
    		};
    		
    		groups.Last().Records.Add(level);
    	}
    	
    	// groups now contains a list of each section from the file with a list of records
    }
    
    public class Record
    {
    	public int Level { get; set; }
    	public int Row { get; set; }
    	public int Col { get; set; }
    }
    
    public class Group
    {
    	public int Chromosome { get; set; }
    	public List<Record> Records { get; set; }
    }
