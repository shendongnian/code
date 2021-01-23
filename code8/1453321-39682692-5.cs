    //Initializing a few things first...
    Filter myFilter = new Filter();
    IQueryable<SomeClass> query = new Queryable();//Just a generated type
    //This is for my first example from above
    FilterCommon(query, myFilter, x => x.Contacts, x => x.ContactID);
    //Second example without filter parameter
    FilterCommon(query, myFilter.Contacts, x => x.ContactID);
    FilterCommon(query, myFilter.SomethingElse, x => x.SomethingElseID);
