    if(IsRunningOnWindows())
    {
    
      // Use MSBuild
      foreach(string currenproject in projectslocation)
      {
      MSBuild(currenproject, new MSBuildSettings {
              ArgumentCustomization = args=>args.Append(
                  "/flp:logfile=MyProjectOutput.log;verbosity=diagnostic"
              )
          }.SetConfiguration(configuration)
          .SetVerbosity(Verbosity.Minimal));
      }
    }
