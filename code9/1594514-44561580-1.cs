    using (OffregHive hive = OffregHive.Open(@"D:\Daten\VisualStudio2017\2\privateregistry.bin"))
    {
      string fullName = hive.Root.FullName;
      OffregKey ork = hive.Root.OpenSubKey(@"Software\Microsoft\VisualStudio");
    
      foreach(SubKeyContainer key in ork.EnumerateSubKeys())
      {
        System.Console.WriteLine(key.Name);
      }
    }
