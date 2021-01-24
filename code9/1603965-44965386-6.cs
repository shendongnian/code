    book = new Book()
    {
        Author = "Niccolò Ammaniti",
        Name = "Come Dio comanda"
    };
    
    Person person = context.People.Single(_ => _.FirstName == "bubi");
    person.OwnedBooks.Add(book);
    
    context.SaveChanges();
    
    book.Owners.Remove(person);
    context.SaveChanges();
