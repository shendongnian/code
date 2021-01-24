      public ActionResult Save(object commingJson)
        {
             PersonModel person = new PersonModel();
              try{
               person.FName = commingJson.FName;
               person.LName = commingJson.LName ;
               }
              catch(Exception)
               {
                 //Binding Failed invalid json
                }
               
             int countInObject = GetAttrCount(commingJson);
             int countInModel = GetAttrCount(person);
                  if(countInObject != countInModel )
                 {
                   //Json have more or less value then model  
                 }
            if(ModelState.IsValid) // returns true
            // do things
            return View(person)
        }
    
       
        
       public int GetAttrCount(obecjct countObject) 
    {
        Type type = typeof(countObject);
        int attributeCount = 0;
        foreach(PropertyInfo property in type.GetProperties())
        {
         attributeCount += property.GetCustomAttributes(false).Length;
        }
    return attributeCount ;
    }
