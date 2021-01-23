    public class BookDB
    {
         public bool Save(Book obj)
         {
              using(SqlConnection con = RepositoryUtility.GetConnection())
              {
                  // here code to check and save the object
                  ....
              }
         }
         public Book LoadByKey(int bookID)
         {
              using(SqlConnection con = RepositoryUtility.GetConnection())
              {
                  Book aBook = new Book();
                  // here goes the code to load a book from the db using the primarykey
                  ....
                  return aBook
              }
         }
         ... other db methods based ....
    }
