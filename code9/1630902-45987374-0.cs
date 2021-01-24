    void Main()
    {
    	string line = "bob#5368 3";
    	GuildUser user = new GuildUser( line );
    }
    
    public class GuildUser
    {
    	public string Name { get; set;}
    	public int Id { get; set;}
    	public int Warnings { get; set;}
    	public GuildUser( string line )
    	{
    		Match match = Regex.Match( line, @"(.+)?#(\d+) (\d+)" );
    		if ( !match.Success ) throw new Exception( "Couldn't parse line: " + line );
    		Name = match.Groups[1].Value;
    		Id = int.Parse( match.Groups[2].Value );
    		Warnings = int.Parse( match.Groups[3].Value );
    		
    	}
    }
