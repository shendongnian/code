    var viewModel = usersAndBook.Select(u => new UserViewModel()
            {
               Id = u.Id,
               Name = u.Name,
               LatestBookName = u.Books.Count > 0 
                    && u.Books.OrderByDescending(b => b.Id).FirstOrDefault().Name, 
    
               //this does work:
               hasCoverImage = u.Books.Count > 0 
                     && SqlFunctions.DataLength
                    (c.Books.OrderByDescending(b => b.Id).First().CoverImage) > 0
            }
