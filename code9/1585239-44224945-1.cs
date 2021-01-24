	// GET /api/books/{id}
    [HttpGet("{id}", Name = "GetBook")]
    public IActionResult Get(int id)
    {
        var book = new Book { 
			Title = "Test Title 1", 
			Author = "Test Author 1", 
			ISBN="Test ISBN 1", 
			PublishingDate = DateTime.Today.AddYears(-90).AddDays(-73) 
		};
		return new ObjectResult(book);
    }
	
	// POST api/books
	[HttpPost]
	public IActionResult Post([FromBody] Book book)
	{
		if (book == null)
		{
			return BadRequest();
		}
		
		// code to add book to database
		//_context.Books.Add(book);
		//_context.Books.SaveChanges();
        return CreatedAtRoute(
            routeName: "GetBook",
            routeValues: new { id = 1 },
            value: book);
	}
