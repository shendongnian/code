    public static bool IsNotEmpty(object obj)
    {
      if (obj is ICollection)
        return ((ICollection)obj).Any();
      else if (obj is IEnumerable)
        return ((IEnumerable)obj).Any();
      else
        return true; 
    }
