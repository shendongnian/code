    // Users Grid -- Notice the select new UserGridViewModel()
    var query = from u in db.Users
            join br in db.BooksReserveds on u.Id equals br.UserId
            join b in db.Books on br.BookId equals b.Id
            where br.DateOut < DateTime.Today
            orderby br.DateOut
            select new UserGridViewModel() { User = u, BooksReserved = br, Book = b };
