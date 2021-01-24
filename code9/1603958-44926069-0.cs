    var oldBooks = Context.PersonBook.Where(e => e.PersonId == PersonId).ToDictionary(e => e.BookId);
    var newBooks = ListOfBooks.ToDictionary(e => e.BookId);
    Context.PersonBook.RemoveRange(oldBooks.Values.Where(e => !newBooks.ContainsKey(e.BookId)));
    Context.PersonBook.AddRange(newBooks.Values.Where(e => !oldBooks.ContainsKey(e.BookId)));
 
