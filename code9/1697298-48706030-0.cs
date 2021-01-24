    public override string ToString()
    { 
      try 
      {
      
         var str = "[" + Header + "] BODY: " + 
            (PlusEnvironment
               .GetDefaultEncoding()
               .GetString(Body)
               .Replace(Convert.ToChar(0).ToString(), "[0]"));
        // return if no exception is thrown
        return str;
      }
      catch (System.Exception e)
      {
        return e.Message:
      }
  }
