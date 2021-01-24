    public bool Continue( ThreadWorker sender, ref ThreadTask task )
    {    
        if ( _backlog.Count > 0 )
        {
            System.Diagnostics.Debug.WriteLine( "Waiting for a task" );
            while ( _backlog.Count > 0 )
            {
                if ( _backlog.TryDequeue( out task ) )
                {
                    System.Diagnostics.Debug.WriteLine( "Got a task" );
                    return false;
                }
            }
            // Watch for this message
            System.Diagnostics.Debug.WriteLine( "Got NO task" );
        }
        task = null;                                        
        _available.Push( sender );                          
        return true;                                        
    }
