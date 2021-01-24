    public static string GetString(IEnumerable<object> items)
     { 
        var item = items.FirstOrDefault();
        if(item == null)
        {
            return string.Empty;
        }
        switch(item)
        {
            case Material material:
              foreach(var temp in items.Cast<Material>())
              {
              }
              break;
            case Movement movement:
            foreach (var temp in items.Cast<Movement>())
            {
            }
                break;
            default:
                return string.Empty;
        }
        return "...";
        
    }
