    Account a = db.Account.Find( currentLoggedInUser );
    var xxx = db.PackageModel
            .Where( p => p.ID == 1 ) // <-- this part is Linq-to-Entities
            .AsEnumerable() // <-- this causes the rest of the Linq construct to be evaluated in Linq-to-Objects
            .Select( p => new PackageViewModel() // <-- this part is Linq-to-Objects
            {
                ID = x.ID,
                acc = a // <-- now you can capture non-trivial values
            });
