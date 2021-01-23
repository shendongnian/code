    class AuthorServiceModel
    {
        int AuthorId { get; set; }
        string FirstName { get; set; }
        // ...
    }
    class LibraryService : ILibraryService      // if DI is used
    {
        public AuthorServiceModel GetAuthorById(int id)
        {
            // error handling/logging may be put here, if an invalid id is provided
            var author = context.Authors.Get(id);
            // auto mapping can be used to avoid the typing - check http://automapper.org/
            var sm = new AuthorServiceModel { AuthorId = author.AuthorId, FirstName = author.FirstName };
            return sm;
        }
        // 
    }
    The controller will never have to know about your data access layer
