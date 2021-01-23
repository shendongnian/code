    var books = new List<ActualClass>
    {
       new ActualClass { BookName = "A", DateOfIssue = new DateTime(2015, 10, 10, 10, 10, 0), IssuerName = "1" },
       new ActualClass { BookName = "B", DateOfIssue = new DateTime(2015, 10, 10, 10, 10, 0), IssuerName = "1" },
       new ActualClass { BookName = "C", DateOfIssue = new DateTime(2015, 10, 10, 10, 10, 0), IssuerName = "1" },
       new ActualClass { BookName = "D", DateOfIssue = new DateTime(2015, 10, 10, 10, 10, 0), IssuerName = "2" },
       new ActualClass { BookName = "E", DateOfIssue = new DateTime(2015, 10, 10, 12, 10, 0), IssuerName = "2" },
       new ActualClass { BookName = "F", DateOfIssue = new DateTime(2015, 10, 10, 12, 10, 0), IssuerName = "2" }
    };
    
    var result = books.GroupBy(x => new { x.IssuerName, x.DateOfIssue })
                    .Select(b => new ViewModel
                    {
                        Books = b.Select(bn => bn.BookName).ToList(),
                        DateOfIssue = b.Key.DateOfIssue,
                        IssuerName = b.Key.IssuerName
                    });
