    string u = the user name provided by someone;
    string p = the password provided by someone;
    
    List<DataRow> list = dt.AsEnumerable().ToList();
    bool isValidUser = false;
    var user = list.SingleOrDefault(x => x.User == u);
    if (user != null)
    {
        string actualHash = CalculateHash(p, user.PasswordSalt);
        isValidUser = actualHash == u.PasswordHash;
    }
