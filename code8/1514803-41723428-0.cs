      using System.Reflection;
      ...
      var fields = typeof(Person)
        .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        .Select(field => field.Name);
      Console.Write(string.Join(Environment.NewLine, fields));
