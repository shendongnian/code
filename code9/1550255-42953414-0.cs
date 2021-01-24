      using System.Linq;
      using System.Reflection;
      ...   
      MyClass source = ...
      var sum = source
        .GetType()
        .GetProperties(BindingFlags.Instance |
                       BindingFlags.Public | 
                       BindingFlags.NonPublic) // you may want not to read non-public props
        .Where(p => p.CanRead && p.PropertyType == typeof(int))
        .Sum(p => (int) p.GetValue(source));
