	public class Prompts
	{
		public List<Prompt> prompt { get; set; }
	}
	public class Prompt
	{
		public string message { get; set; }
		public int code { get; set;}
	} 
	
	....
	var promptsWeCareAbout = Prompts.prompt.Where(p => p.code == 2041);
	if(promptsWeCareAbout.Any()) 
    {
		string message = promptsWeCareAbout.First().message;
	}
