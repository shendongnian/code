    var yourContext = ((IObjectContextAdapter)db).ObjectContext;
    try {
        yourContext.Connection.Open();
        using (var transaction = new TransactionScope()) {
            
            //you can implement entities.DeleteObject(pu) here
            db.SaveChanges();
            // Do something else
            db.SaveChanges();
            transaction.Complete();
        }
    } finally {
        yourContext.Connection.Close();
    }
