    HashSet<YourType> bob;
    
    using (var db1 = new DataBase1Entities())
    {
        bob = new HashSet<YourType>(db1.Table2.Select(z => z.Table2Col);
    }
    
    using (var db2 = new DataBase2Entities())
    {
         var list = (from obj in db2.Table1
                     where !bob.Contains(obj.Table1Col)
                     select obj).ToList();
    }
