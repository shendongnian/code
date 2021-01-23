    public class DisplaySourceViewComponent : ViewComponent
    {
    	public DisplaySourceViewComponent(IHostingEnvironment hostingEnvironment)
    	{
    		WebRootPath = hostingEnvironment.WebRootPath;
    		ContentRootPath = hostingEnvironment.ContentRootPath;
    	}
    
    	public string ContentRootPath { get; set; }
    
    	public string WebRootPath { get; set; }
    
    	public async Task<IViewComponentResult> InvokeAsync(string executingViewPath, ViewRole viewRole)
    	{
    		if (viewRole != ViewRole.Display)
    		{
    			return new NullViewComponentResult();
    		}
    
    		IEnumerable<string> viewSource = await GetViewSourceAsync(executingViewPath);
    
    		return View(viewSource);
    	}
    
    	private int GetLastContentIndex(List<string> lines)
    	{
    		for (int i = lines.Count - 1; i >= 0; i--)
    		{
    			if (!String.IsNullOrWhiteSpace(lines[i]))
    			{
    				return i;
    			}
    		}
    
    		return -1;
    	}
    
    	private async Task<IEnumerable<string>> GetViewSourceAsync(string executingViewPath)
    	{
    		executingViewPath = executingViewPath.Substring(1).Replace('/', Path.DirectorySeparatorChar);
    
    		string viewFilePath = Path.Combine(ContentRootPath, executingViewPath);
    
    		var lines = new List<string>();
    
    		using (var reader = new StreamReader(viewFilePath, Encoding.UTF8))
    		{
    			string line;
    
    			while ((line = await reader.ReadLineAsync()) != null)
    			{
    				if (line.StartsWith("@model")) continue;
    				if (line.StartsWith("@await") && line.Contains(@"InvokeAsync(""DisplaySource""")) continue;
    
    				lines.Add(line);
    			}
    		}
    
    		return Trim(lines);
    	}
    
    	private IEnumerable<string> Trim(List<string> lines)
    	{
    		var contentLines = new List<string>();
    
    		int lastContentIndex = GetLastContentIndex(lines);
    
    		for (int i = 0; i <= lastContentIndex; i++)
    		{
    			string line = lines[i];
    
    			if (String.IsNullOrWhiteSpace(line) && contentLines.Count == 0) continue;
    
    			contentLines.Add(line);
    		}
    
    		return contentLines;
    	}
    }
    
    public class NullViewComponentResult : IViewComponentResult
    {
    	public void Execute(ViewComponentContext context)
    	{
    		return;
    	}
    
    	public Task ExecuteAsync(ViewComponentContext context)
    	{
    		return Task.CompletedTask;
    	}
    }
