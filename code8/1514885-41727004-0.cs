    Account a = db.Account.Find( currentLoggedInUser );
    var xxx = db.PackageModel.Where(y => y.ID== 1)
            .Select(x => new PackageViewModel()
            {
                ID= x.ID,
                acc = a // <-- you're capturing `a`
            });
            
