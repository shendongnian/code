    private void ReadFile()
    {
    	InitializeComponent();
    
    	//load all  lines
    	var lines = File.ReadAllLines(@"c:\temp\file.txt").ToList().;
    	//mark indexes where sections start
    	var sectionIndexes = lines
    		.Where(l => l.StartsWith("[") && l.EndsWith("]"))
    		.Select(l => lines.IndexOf(l)).ToList();
    
    	//now make list of tuples. Each tuple contains start of section (Item1) and last line of section (Item2)
    	var sections = Enumerable.Zip(sectionIndexes, sectionIndexes.Skip(1), (a, b) => new Tuple<int, int>(a, b-1)).ToList();
    
    	//for each tuple (each section)
    	foreach (var item in sections)
    	{
    		//process section name (line with raound brackets
    		ProcessSection(lines[item.Item1], lines.Where(l => lines.IndexOf(l) > item.Item1 && lines.IndexOf(l) <= item.Item2));
    	}
    }
    
    private void ProcessSection(string sectionName, IEnumerable<string> lines)
    {
    	Console.WriteLine("this is section {0} with following lines: {1}", sectionName, string.Join(", ", lines.ToArray()));
    }
