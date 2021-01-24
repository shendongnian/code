    using (Transaction _transaction = realm.BeginWrite())
    {
        var trans = new Models.Transaction();
        ...
    
        realm.Add(trans);
        foreach ( var details in Trans.Rows )
        {
            var row = new TransactionDetails();
            ...
            trans.Rows.Add( details ); // Error here every time           
        }
        _transaction.Commit();
    }
