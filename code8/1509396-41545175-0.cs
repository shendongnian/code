    using System.Data.Entity;
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public abstract class ApplicationContext : DbContext
    {
         //Instructions.........
    }
