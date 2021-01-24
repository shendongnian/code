    var books = from x in dt
                            join y in db.BookFiles
                            on
                            new { printid = x.Field<string>("PrintID"), packageid = x.Field<string>("PackageID") }
                            equals
                            new { printid = y.PrintId, packageid = y.PackageID }
                            select y;
    
                foreach (var book in books.ToList())
                {
                  \\Do Something
                }
