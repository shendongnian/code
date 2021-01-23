    class Page<T>
    {
        public Page(SqlConnection conn, int pageNr, int pageSize)
        {
            this.PageNr = pageNr;
            this.PageSize = pageSize;
        }
        private readonly SqlConnection conn;
        public int PageSize {get; private set;}
        public int PageNr {get; private set;}
        
        public IEnumerable<T> ReadContents()
        {
            int offset = this.PageNr * this.PageSize;
            int fetch = this.PageSize;
            string cmdText = "SELECT col1, col2, ..."
              + " FROM ... "
              + " WHERE ... "
              + " ORDER BY -- " 
              // this is a MUST there must be ORDER BY statement
              //-- the paging comes here
              + $" OFFSET {offset} ROWS"
              + $" FETCH NEXT {fetch} ROWS ONLY;";
            using (SqlCommand cmd = new SqlCommand("cmdText, conn))
            {
                using (var sqlDataReader = cmd.ExecuteQuery())
                {
                    List<T> readItems = sqlDataReader...;
                    // you know better than I how to use the SqlDataReader                    
                    return readItems
                }
            }
        }
    }
