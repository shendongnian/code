    DataSet ds = null;
    
    //populate the dataset ds from SQL Server using ADO .Net
    /*
    Your database would have two tables:
    Books : containing Id, BookName columns -> This will get populated in Tables[0] of dataset
    BookImages: containing BookId, BookImageUrl columns -> This will get populated in Tables[1] of dataset
    Here BookId column in BookImages table is foreign key referring to Id column in Books table 
                 */
    
    //tables[0] contains main attributes of a book e.g. Name, Id etc.
    DataTable dataTab = ds.Tables[0];
    
    var bookList = dataTab.AsEnumerable().Select(x => new Book                      {
                   ID = int.Parse(x["Id"].ToString()),
                   BookName = x["BookName"].ToString(),
                 });
    /*tables[1] contains detailed attributes of a book e.g. book image Urls
             * */
    DataTable imageTab = ds.Tables[1];
    foreach (var book in bookList)
    {
        book.BookImageUrl = imageTab.AsEnumerable()
                            .Where(x => Convert.ToInt32(x["BookId"]) == book.ID)
                            .Select(x => x["BookImageUrl"].ToString()).ToList();
    }
