    var qry = /* something to create an IQueryable<T> from your DbContent */
    foreach (var x in qry) {
      // qry has been enumerated: so SQL has been generated and executed
    }
    qry = qry.Where(some-condition);
    foreach (var x in qry) {
      // qry has been enumerated: SQL with extra condition applied is run
    }    
    var e = qry.ToList();
    // Anything done to e is done in memory, there will be no new
    // SQL sent to the DB for the collection/
    var f = e.First();
    // But, as Standard is a lazy property this will generated a query.
    x = e.Standard.SomeProperty;
