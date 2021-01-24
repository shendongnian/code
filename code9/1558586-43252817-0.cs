     // Loop through big file to import each row
    foreach(var item in bigFile)
    {
       // Create DB context each time
       using(DbEntities db = new DbEntities())
       {
          Person person = new Person { FirstName = item.FirstName, LastName = item.LastName };
    
          foreach(var book in item.Books)
          {
             if(!db.Books.Any(m => m.BookId == bookId))
             {
                // Add book to DB if doesn't exist
                Book bookToAdd = new Book { BookId = bookId, Name = book.Name
    
                db.Books.Add(bookToAdd);
             }
    
             person.Books.Add(db.Books.Single(m => m.BookId == bookId));
          }
    
          db.People.Add(person);
    
          db.SaveChanges();
       }
    }
