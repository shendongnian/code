    public void BooksByAuthorExample()
        {
        //Create library 
        IList<Book> myLibrary = new List<Book>();
        //Define first book
        Author hermanM = new Author("Herman Melville");
        IList<Author> authors = new List<Author>();
        authors.Add(hermanM);
        Book mobyDick = new Book("Moby-Dick", authors);
        //Define second book
        Author gamma = new Author("Eric Gamma");
        Author helm = new Author("Richard Helm");
        Author johnson = new Author("Ralph Johnson");
        Author vlissides = new Author("Johm Vlissides");
        IList<Author> gangOfFour = new List<Author>() { gamma, helm, johnson, vlissides};
        Book designPatterns = new Book("Design Patterns - Elements of Reusable Object-Oriented Software", gangOfFour);
        
        //Add books to the library 
        myLibrary.Add(mobyDick);
        myLibrary.Add(designPatterns);
        //Select books written by Richard Helm
        IList<Book> searchResult = myLibrary.Where(x => x.Authors.Contains(helm)).ToList();
    }
