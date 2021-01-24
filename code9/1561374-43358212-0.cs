    // Users Grid
    //by using var here and select new this object is anonymous.
    var query = from u in db.Users
                join br in db.BooksReserveds on u.Id equals br.UserId
                join b in db.Books on br.BookId equals b.Id
                where br.DateOut < DateTime.Today
                orderby br.DateOut
                select new { User = u, BooksReserved = br, Book = b };
    UsersGridView.DataSource = query.ToList();
    UsersGridView.DataBind();
