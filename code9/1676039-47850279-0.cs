    // Check myObj
    MyObjectType myObj = ...         // instead of var, so you are certain you have the right type
    Debug.Assert(myObj != null);
    // only if Year, Quarter, Week are classes:
    Debug.Assert(myObj.Year != null);   
    Debug.Assert(myObj.Quarter != null);
    Debug.Assert(myObj.Week != null);
    // check your db:
    Debug.Assert(db != null);
    Debug.Assert(db.MyTable != null);
    int count1 = db.MyTable.Count();
    int count2 = db.MyTable
        .Where(x => x.Year == MyObj.Year 
            && x.Quarter == MyObj.Quarter
            && x.Week == MyObj.Week)
        .Count();
    bool hasAny = db.MyTable
        .Where(x => x.Year == MyObj.Year 
            && x.Quarter == MyObj.Quarter
            && x.Week == MyObj.Week)
        .Any();
    // if all this works, your statement should also work
    hasAny = db.MyTable
        .Any(x => x.Year == MyObj.Year 
            && x.Quarter == MyObj.Quarter
            && x.Week == MyObj.Week);
