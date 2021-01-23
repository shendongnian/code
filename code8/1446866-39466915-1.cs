    private void Process_NoTracking()
    {
        var totalProcessedCounter = 0;
    
        using( var context = new MyDbContext() )
        {
            while( true )
            {
                var list = context
                              .MyClass
                              .AsNoTracking()
                              .OrderBy( x => x.Id )
                              .Skip( totalProcessedCounter )
                              .Take( 1000 )
                              .ToList(); 
    
                if( !list.Any() )
                    break;
    
                UpdateList( list );
    
                totalProcessedCounter += list.Count;
            }
        }
    }
