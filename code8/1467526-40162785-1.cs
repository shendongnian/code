    [ResponseType(typeof(BookDto))]
            public async Task<IHttpActionResult> GetBook(int id)
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
