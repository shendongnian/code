    private void BWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        string filename = GetFileName();
    
        if ( !string.IsNullOrEmpty( filename ) )
        {
            // Do long task
        }
        else
        {
            throw new InvalidOperationException( "my custom message error" );
        }
    }
    
    private void BWorker_RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e )
    {
        if ( e.Error != null )
        {
            // my custom message error
            Logger.Process( e.Error.ToString() );
        }
        else if ( e.Cancelled )
        {
            Logger.Process( "Cancelled." );
        }
        else
        {
            Logger.Process( "Success." );
        }
    }
