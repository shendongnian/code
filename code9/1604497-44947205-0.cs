    using (var transaction = new System.Transactions.TransactionScope())
    {
        // some changes and db.SaveChanges();
        transaction.Commit();
    }
