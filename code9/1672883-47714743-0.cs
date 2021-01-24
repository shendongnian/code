    //MyClass has Id as property, this is set by the DB server
    var myObject = new MyClass { NotIdProp = someVal; }
    int idAfterInsert; //or string if using GUID for Id
    
    //transaction and then dispose DB context
    using (var db = new MyContext())
    {
        //add the entity object
        db.MyTable.Add(myObject);
       //now myObject will have its Id set by the DB server
       idAfterInsert = myObject.Id;
       
      //that's it if you don't want to Save Changes
      
    }
