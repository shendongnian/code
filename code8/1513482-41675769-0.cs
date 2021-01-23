    string sql = "select ...";
    string hash = "book_" + sql.GetHashCode();
    Book b = null;
    if (HttpRuntime.Cache[hash] != null)
    {
         b = (Book)HttpRuntime.Cache[hash];
    }
    else
    {
         b = SelectBookFromSql(sql);
         HttpRuntime.Cache[hash] = b;
    }
