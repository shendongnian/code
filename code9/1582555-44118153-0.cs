         **public static async Task<IPagedList<BookInfo>> getAllBooksInfo(int page, int itemsPerPage)
            {
                List<BookInfo> bookinfo = new List<BookInfo>();
        
                    bookinfo = (from o in entities.BookInfoes
                              orderby o.Title descending //use orderby, otherwise Skip will throw an error
                              select o)
                              .Skip(itemsPerPage * page).Take(itemsPerPage)
                              .ToList();
                int totalCount = bookinfo.Count();//return the number of pages
    //changes made to the below line
                IPagedList<BookInfo> pagebooks = bookinfo.ToPagedList(1, 10);
                return pagebooks;//the query is now already executed, it is a subset of all the orders.
            }**
