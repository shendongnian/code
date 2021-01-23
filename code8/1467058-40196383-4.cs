    if (File.Exists(targetFile))
    {
      if (fi.GetAssemblyVersion() > new FileInfo(targetFile).GetAssemblyVersion())
      {
        // If version to deploy is newer than current version
        // Delete current version and copy the new one
        // FAILS HERE
        File.Copy(fi.FullName, targetFile, true);
      }
    }
