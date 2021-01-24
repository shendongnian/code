    var result = dbResults.Join(webResults, db => db.Id, web => web.Id
                                (db, web) => {
                                    db.SomePropFromWeb = web.SomeProp;
                                    return db;
                                });
