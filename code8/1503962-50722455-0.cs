    public async Task<IActionResult> Create([FromForm] CreateParameters parameters, IFormFile file)
    {
    	const string filePath = "./Files/";
    	if (file.Length > 0)
    	{
    		using (var stream = new FileStream($"{filePath}{file.FileName}", FileMode.Create))
    		{
    			await file.CopyToAsync(stream);
    		}
    	}
    
    	// Save CreateParameters properties to database
    	var myThing = _mapper.Map<Models.Thing>(parameters);
    	
    	myThing.FileName = file.FileName;
    
    	_efContext.Things.Add(myThing);
    	_efContext.SaveChanges();
    	
    	
    	return Ok(_mapper.Map<SomeObjectReturnDto>(myThing));
    }
