    var book = new Book()
    { 
        Id = 20 
    }; 
 
    using (var context = new DatabaseContext()) 
    { 
        context.Books.Attach(book);
        book.Title = "Updated  Title";  
        context.SaveChanges(); 
    }
