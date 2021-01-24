    public class AccessorClass
    {
        public static YourDBEntities GetDataContext()
        {
            return new YourDBEntities("metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=\";data source=xxxxxxx;initial catalog=xxxxxxx;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework\";");
        }
    }
