    var query = _bookRepository.GetQueryable();
        
    if (!string.IsNullOrEmpty(searchOptions.Title))
       query = query.Where(x.Title.Contains(searchOptions.Title));
        
    if (!string.IsNullOrEmpty(searchOptions.AuthorName))
       query = query.Where((x.LinkedAuthor.FirstName + " " + x.LinkedAuthor.LastName).Contains(searchOptions.AuthorName));
    
    var books = query.ToList(); // or i don't know, just enumerate 
