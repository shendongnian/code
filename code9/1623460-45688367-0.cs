    public static class callResources
      {
    
        public static ObservableCollection<string> callAllResources()
        {
          var properties = typeof(Properties.Resources).GetProperties(
    System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic |
    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static);
    
          ObservableCollection<string> col = new ObservableCollection<string>();
          foreach (var propertyInfo in properties)
          {
            var s = propertyInfo.Name;
            if (s != "ResourceManager" && s != "Culture")
            {
    
              col.Add(s);
    
            }
          }
          return col;
        }
      }
