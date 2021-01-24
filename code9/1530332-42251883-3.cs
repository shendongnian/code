    public static bool IsNotEmpty(object obj)
    {
      if (obj is IEnumerable)
        return ((IEnumerable)obj).Any();
      else
        return true; 
    }
