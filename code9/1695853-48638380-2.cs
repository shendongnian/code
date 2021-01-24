    public static CustomItem FirstCustom(this IEnumerable<CustomItem> source, int id) { 
      if (null == source)
        throw new ArgumentNullException("source"); // validate public methods' arguments 
      CustomItem result = source.FirstOrDefault(item => item.Id == id);
      if (null == result)
        throw new ArgumentException($"Id {id} has not been found!", "id");
      else
        return result;  
    }
 
   
