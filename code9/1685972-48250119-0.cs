    IQueryable<Whatever> query = db.AllMembers;
    if(!string.IsNullOrEmpty(phoneNumber))
        query = query.Where(m => m.PhoneNumber == phoneNumber);
    if(!string.IsNullOrEmpty(fName))
        query = query.Where(m => m.MemberFirstName == fName);
    if(!string.IsNullOrEmpty(lName))
        query = query.Where(m => m.MemberLastName == lName);
    // ...
    var results = query.Take(maxCount).ToList();
