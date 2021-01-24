        List<Users> UserListCur = new List<Users>();
        List<Users> UserListLR = new List<Users>();
        FileHelperEngine engine = new FileHelperEngine(typeof(Users));
        var records = engine.ReadFile(@"C:\\users.csv");
        var lrrecords = engine.ReadFile(@"C:\\lastrun.csv");
        foreach (Users record in records)
        {
            UserListCur.Add(record);
        }
        foreach (Users record in lrrecords)
        {
            UserListLR.Add(record);
        }
        UserListCur.RemoveAt(0);
        UserListLR.RemoveAt(0);
        var UserListLRhash = new HashSet<Users>(UserListLR, new UsersEqualityComparer());
        UserListCur.RemoveAll(x => UserListLRhash.Contains(x));
