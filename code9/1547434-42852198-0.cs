    private object GetProperty(Form obj, string propName)
    {
       var p = ob.GetType().GetProperty(propName);
       if(p != null)
       {
           return p.GetValue(ob);
       }
       return null;
    }
    
