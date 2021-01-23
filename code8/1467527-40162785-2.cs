    [ProducesResponseType(typeof(BookDto), 200)]
    [ProducesResponseType(typeof(object), 201)]
             public async Task<IActionResult> GetBook(int id)
                {
                    BookDto book = await db.Books.Include(b => b.Author)
                        .Where(b => b.BookId == id)
                        .Select(AsBookDto)
                        .FirstOrDefaultAsync();
                    if (book == null)
                    {
                        return NotFound();
                    }
        
                    return Ok(book);
                }
