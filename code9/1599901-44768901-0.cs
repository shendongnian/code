    Parallel.ForEach( 
        fileNames, // the filenames IEnumerable<string> to be processed
        () => new YourDbContext(), // Func<TLocal> localInit
        ( fileName, parallelLoopState, dbContext ) => // body
        {
            // your logic goes here
            // LookUpFileInfoInDB( dbContext, fileName )
            // MoveFile( ... )
            // RegisterFileMoveInDB( dbContext, ... )
            // pass dbContext along to the next iteration
            return dbContext;
        }
        ( dbContext ) => // Action<TLocal> localFinally
        {
            dbContext.SaveChanges(); // single SaveChanges call for each thread
            dbContext.Dispose();
        } );
