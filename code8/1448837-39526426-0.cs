    public class LibraryRepository : IBookRepository, I
        {
            LibraryContext context = new LibraryContext();
    
            public decimal findBookPrice(int book_id=0)
            {
                var bookprice = (
                                from r in context.Books
                                where r.Book_Id == book_id
                                select r.Price
                                ).FirstOrDefault();
    
                return bookprice;
    
            }
    
            public decimal findBookPrice(int book_id=0, string bookname=null)
            {
                var bookprice = (
                                 from book in context.Books
                                 where book.Book_Id == book_id & book.Book_Title == bookname
                                 select book.Price
                                 ).FirstOrDefault();
    
                return bookprice;
    
            }  
    
        }
