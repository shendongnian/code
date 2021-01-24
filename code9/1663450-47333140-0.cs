    internal sealed class Copier: IDisposable
    {
      static object sync = new object();
      bool quit;
      FileSystemWatcher watcher;
      List<string> work;
      
      internal Copier( string pathToWatch )
      {
        work = new List<string>();
        watcher = new FileSystemWatcher();
        watcher.Path = pathToWatch;
        watcher.Create += QueueWork;
        ThreadPool.QueueUserWorkItem( TryCopy );
      }
      void Dispose()
      {
        lock( sync ) quit = true;
      }
      
      void QueueWork( object source, FileSystemEventArgs args )
      {
        lock ( sync )
        {
          work.Add( args.FullPath );
        }
      }
      
      void TryCopy( object args )
      {
        List<string> localWork;
        while( true )
        {
          lock ( sync ) 
          { 
            if ( quit ) return;  //--> we've been disposed
            localWork = new List<string>( work );
          }
          foreach( var fileName in localWork )
          {
            var locked = true;
            try
            {
              using 
              ( var throwAway = new FileStream
                ( fileName, 
                  FileMode.Open,
                  FileAccess.Read,
                  FileShare.None
                )
              ); //--> no-op  - will throw if we can't get exclusive read        
              locked = false;
            }
            catch { }
            if (!locked )
            {
              File.Copy( fileName, ... );
              lock( sync ) work.Remove( fileName );
            }
          }
        }
      }
    }
