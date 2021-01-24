      using System.Dynamic;
      ...
      dynamic names = new ExpandoObject();
      names.subdir1 = @"C:\MyDir\MySubDir1";
      names.subdir2 = @"C:\MyDir\MySubDir2";
      Directory.CreateDirectory(Path.Combine(names.subdir1, "Something"));
      // Do we have "subdir3" key?
      if ((names as IDictionary<string, object>).ContainsKey("subdir3")) {
        ...
      }
