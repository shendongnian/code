      var wmiQueryString = string.Format( "associators of {{win32_process.Handle={0}}} where resultclass=cim_datafile", handle );
      using ( var searcher = new ManagementObjectSearcher( wmiQueryString ) )
      {
        var results =
          searcher
          .Get( )
          .OfType<ManagementBaseObject>( )
          .SelectMany
          ( df => df.Properties.OfType<PropertyData>( ).Where( pd => pd.Name == "Caption" ) );
        foreach ( PropertyData item in results )
        {
          Console.WriteLine( item.Value );
        }
      }
