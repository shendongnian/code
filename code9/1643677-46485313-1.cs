      using System.Reflection;
      ... 
      var fields = string.Join(", ", typeof(ClassName)
        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        .Select(f => f.Name));
      Console.Write(fields);
