    using(DbEntities db = new DbEntities())
    {
       var listToAdd = new List<Book>();
       var personToAdd = new List<Person>();
    	
       // Get list of all books so don't have to hit every time
       Dictionary<int, Book> books = db.Books.ToDictionary(k => k.BookId, v => v);
    
       // Loop through big file to import each row
       foreach(var item in bigFile)
       {
          Person person = new Person { FirstName = item.FirstName, LastName = item.LastName };
    
          foreach(var book in item.Books)
          {
             if(!books.ContainsKey(book.BookId))
             {
                // Add book to DB if doesn't exist
                Book bookToAdd = new Book { BookId = book.BookId, Name = book.Name };
    			
    			// ADD to list instead
                listToAdd.Add(bookToAdd);
             }
    
             person.Books.Add(books[book.BookId]);
          }
    
    	  // ADD to list instead
          personToAdd.Add(person);
       }
       
       // USE AddRange here instead
       db.Books.AddRange(listToAdd);
       db.People.AddRange(person);
       
       db.SaveChanges();
    }
