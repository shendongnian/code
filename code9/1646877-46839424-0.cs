    void Main()
    {
        var input = @"id i { 
    		any data; any [con=tent] 
    		id j { 
    			any inner data 
    		}
    		id k {
    			bla 
    			id m {
    				any
    			}
    		thing }
    	}";
    	Process(input).Dump();
    }
    
    public class Node {
        public List<Node> InnerNodes;
        public string Contents; 
        public string Name; 
    }
    
    Regex reg = new Regex(@"
    	id\s+(?<name>\w+)\s*\{(?<body>(?<DEPTH>)
    		(?>(?<DEPTH>)\{ | \}(?<-DEPTH>) | (?(DEPTH)[^\{\}]* | ) )*
    		)\}(?<-DEPTH>)(?(DEPTH)(?!))
    	", RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled);
    	
    List<Node> Process(string body){
    	return reg.Matches(body)
    		.Cast<Match>()
    		.Select(x=>new Node{
    			Name=x.Groups["name"].Value,
    			Contents=x.Groups["body"].Value.Trim(),
    			InnerNodes=Process(x.Groups["body"].Value),
    		}).ToList();
    }
