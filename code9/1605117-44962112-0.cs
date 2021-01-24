     public class MyUserCollection
        {
            public List<MyUser> Users { get; set; }
            public SelectList TableList { get; set; }
            public int TotalRows { get; set; }
            
            public MyUserCollection(string search, string sort, string sortdir, int skip, int pageSize)
            {
                TableList = DataFiller.GetTableNames();
                
                Users = GetUsers(search, sort, sortdir, skip, pageSize, out totalRecord);
            }
        }
