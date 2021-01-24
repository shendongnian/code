    public bool IsContainNull(List<SanityResults> myList)
    {
        foreach(var myObject in myList)
        { 
         if(myObject==null) 
          {return false;} 
         else{ 
          foreach(PropertyInfo pi in myObject.GetType().GetProperties())
                {
                    if(pi.PropertyType == typeof(string))
                    {
                        string stringValue = (string)pi.GetValue(myObject);
                        if(string.IsNullOrEmpty(stringValue ))
                        {
                            return true;
                        }
                    }
                   else if(pi.PropertyType == typeof(int))
                    {
                        int intValue = (int)pi.GetValue(myObject);
                        if(intValue==null)
                        {
                            return true;
                        }
                    }
                }
                
        }
                return false; 
}
}
