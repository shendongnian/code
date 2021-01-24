     var booksQuery = books.Where(g => g.GroupId == id).ToList();
     var bookWanted = booksQuery   
                .OrderByDescending(g => int.Parse(g.registrationNumber.Split(':')[0]))
                .ThenByDescending(g=> int.Parse(g.registrationNumber.Split(':')[1]))
                .FirstOrDefault();
