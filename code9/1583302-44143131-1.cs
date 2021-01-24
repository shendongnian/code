    // Input Param
    string tableName = "TblStudents";
    Dictionary<string, Type> myDictionary = new Dictionary<string, Type>()
    {
        { "TblStudents", typeof(TblStudent) },
        { "TblTeachers", typeof(TblTeacher) }
    };
    // Context always same
    DBContext dbContext = new DBContext();
    DbSet dbSet = dbContext.Set(myDictionary[tableName]);
