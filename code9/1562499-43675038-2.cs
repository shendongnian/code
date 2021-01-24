    Type type = obj.GetType();
    PropertyInfo[] properties = type.GetProperties();  
    string lastPropertyWithError = ""; // You can replace this with a list or so  
    foreach (PropertyInfo property in properties)
    {
       try{
        property.SetValue(myDBObj, property.GetValue(myObj, null));
        db.SaveChanges();
       }catch()
       {
         lastPropertyWithError  = property.Name;
       }
    }
    
