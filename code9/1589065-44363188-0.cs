    //first in your base context, define contructor that takes string as database name.
    //It should be something like this 
    public MyContext(string mydbName = "DefaultDBName") : base(mydbName)
            {
            }
    
    // In your getter, do something like this, get database Name from your attributes  
    string dbName =
                (DatabaseName) Attribute.GetCustomAttribute(typeof(T), typeof (DatabaseName));
    if(dbName==null) throw new Exception ("Missing Attribute");
    else
    {
    // .Name might change depending on your attribute
    string DatabaseName = db.Name;
    // then init your context 
        using (var db = new MyContext(DatabaseName))
        {//do something }
    }
