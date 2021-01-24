      bool legacyPaths;
      if (AppContext.TryGetSwitch("Switch.System.IO.UseLegacyPathHandling", out legacyPaths) && legacyPaths)
      {
        var switchType = Type.GetType("System.AppContextSwitches"); 
        if (switchType != null)
        {
          AppContext.SetSwitch("Switch.System.IO.UseLegacyPathHandling", false);   
          var legacyField = switchType.GetField("_useLegacyPathHandling", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
          legacyField?.SetValue(null, (Int32)0); 
          AppContext.TryGetSwitch("Switch.System.IO.UseLegacyPathHandling", out legacyPaths);
          Assert.IsFalse(legacyPaths, "Long pathnames are not supported!");
        }
      }
