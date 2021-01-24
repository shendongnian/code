    **Replace Method1() method**
     public Method1()
                : base("name=DB_Entities" )
            {
               
            //}
    **With**
             public Method1()
              
            {
                this.Database.Connection.ConnectionString = GlobalVariable.Conn;
            }
    
    you can replace GlobalVariable.Conn with your connection srting or get it from Globalvaliable class file
