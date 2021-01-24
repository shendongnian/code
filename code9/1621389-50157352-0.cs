     var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
     var collection = field.GetValue(_memoryCache) as ICollection;
     var items = new List<string>();
     if (collection != null)
     foreach (var item in collection)
     {
          var methodInfo = item.GetType().GetProperty("Key");
          var val = methodInfo.GetValue(item);
          items.Add(val.ToString());
     }
