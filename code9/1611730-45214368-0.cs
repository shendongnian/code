    using (TransactionScope scope = new TransactionScope()) {
         using(var sqlCon = new SqlConnection(ConnectionString)) {
            // implement logic here
         }
         scope.Complete();
    }
