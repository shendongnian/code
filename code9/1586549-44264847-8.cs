    var wmiQueryString = string.Format( "references of {{win32_process.Handle={0}}}", handle );
    using ( var searcher = new ManagementObjectSearcher( wmiQueryString ) )
    using ( var results = searcher.Get( ) )
    {
      foreach ( ManagementObject item in results )
      {
        Console.WriteLine( item.ClassPath ); //--> turns out this is the cim_processexecutalbe
    
        //--> and these are it's properties...with references to cim_datafile...  
        foreach ( PropertyData prop in item.Properties )
        {
          Console.WriteLine( "{0}: {1}", prop.Name, prop.Value );
        }
      }
    }
