    var orderedBooksAndComments = = books.Where(book => book.UserId == userId).Select(book =>
                new BookAndComment
                {
                    DateTime = book.DateTime,
                    Book = book
                }).Union(comments.Where(comment => comment.UserId == userId).Select(comment =>
                    new BookAndComment
                    {
                        DateTime = comment.DateTime,
                        Comment = comment
                    }
                )).OrderByDescending(bookAndComment => bookAndComment.DateTime).ToList();
