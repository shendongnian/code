    IEnumerable<Table1> myTableCollection = myDbContext.Table1s
        .Where(table => table...)
    foreach (Table1 table1 in myTableCollection)
    {
         bool surNameOk = table1.CheckSurName();
         Process(surNameOk);
    }
