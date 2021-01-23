    using Microsoft.AspNetCore.Hosting;
    .......
    private IHostingEnvironment _environment;
    
    public HomeController(IHostingEnvironment environment)
    {
    	_environment = environment;
    }
    [HttpPost]
    [ValidateAntiForgeryToken]        
    public IActionResult Index(IFormCollection formdata)
    {
     var files = HttpContext.Request.Form.Files;
     foreach (var file in files)
     {
    	 var uploads = Path.Combine(_environment.WebRootPath, "Images");
    	 if (file.Length > 0)
    	 {
    		string FileName = Guid.NewGuid(); // Give file name
    		using (var fileStream = new FileStream(Path.Combine(uploads, FileName), FileMode.Create))
    		{
    			file.CopyToAsync(fileStream);
    		}		
    	 }
      }
    }
