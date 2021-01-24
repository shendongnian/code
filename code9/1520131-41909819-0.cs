       public class TestContext : DbContext
        {
            
           // this is wt we use in application we can delete default ctor it is not required 
            public TestContext(string connectionName)
          
            {
               // i m reading a already encrypted connection string from config 
               // decrpt it and set the connction of db context
                var conn = ConfigurationManager.ConnectionStrings["EncryptedConnection"].ConnectionString;
                this.Database.Connection.ConnectionString = Encrypt.DecryptString(conn, "myKey");
            }
      
            public virtual DbSet<Contact> Contacts { get; set; }
     
        }
