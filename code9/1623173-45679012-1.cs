    foreach (var bowerRoot in bowerRoots.Select(x => x.FullPath))
    {
      try
      {
        var exitCodeWithArgument = StartProcess("C:/Users/gary.park/AppData/Roaming/npm/bower.cmd", new ProcessSettings {
            Arguments = "install",
            WorkingDirectory = bowerRoot
        });
        Information("Exit code: {0}", exitCodeWithArgument);
      }
      catch (Exception ex)
      {
          Information(string.Format("Failed on {0}, {1}", bowerRoot,   ex.Message));
      }
    }
