    public static bool IsWindowsCurrentGen()
    {
      if (Environment.OSVersion.Version.Major >= 6)
        return true;
      else
        return false;
    }
