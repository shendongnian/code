    public Author (string name, List<string> books = null) {
       if(String.isNullOrWhiteSpace(name)) 
          throw new ArgumentException("name is missing");
 
       // P.S. no public setter properties to undo construction
       Name = name;
       Books = books;  
    }
    // suggestion: rewrite to use params keyword to add 1 - many at once
    public void AddBook( title) {
       if (String.isNullORWhitespace(title)) return;
       Books.Add(title);  // allows duplicates, fyi.
