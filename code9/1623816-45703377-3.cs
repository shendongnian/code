    public static class Utility
        {
            public static object ToType<T>(this object obj, T type)
            {
                //create instance of T type object:            
                object tmp = Activator.CreateInstance(Type.GetType(type.ToString()));
    
                //loop through the properties of the object you want to covert:          
                foreach (PropertyInfo pi in obj.GetType().GetProperties())
                {
                    try
                    {
                        //get the value of property and try to assign it to the property of T type object:
                        tmp.GetType().GetProperty(pi.Name).SetValue(tmp, pi.GetValue(obj, null), null);
                    }
                    catch (Exception ex)
                    {
                        // Logging.Log.Error(ex);
                    }
                }
                //return the T type object:         
                return tmp;
            }       
        }
