    var books = _bookRepository.GetAll();
    
    if (!string.IsNullOrEmpty(searchOptions.Title))
        books = books.Where(x.Title.Contains(searchOptions.Title));
    
    if (!string.IsNullOrEmpty(searchOptions.AuthorName))
        books = books.Where((x.LinkedAuthor.FirstName + " " + x.LinkedAuthor.LastName).Contains(searchOptions.AuthorName));
