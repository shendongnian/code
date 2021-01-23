    var session = ... // get an NHiberante ISession
    var transaction = session.BeginTransaction();
    var conn = session.Connection;
    var dbConnection = conn as System.Data.Common.DbConnection;
    
    // do the stuff with DbConnection
    transaction.Commit();
    // or
    transaction.Rollback();
