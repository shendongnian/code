    public class MyDatabaseHandler
    {
        public void CreateTable<T>()
        {
            // How do I get the table name "mydatatable"?
            var type = typeof(T);
            var tableAttribute = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), inherit: false).FirstOrDefault();
            var tableName = tableAttribute?.Name;
            // How do I get the column names and types?
            var columns = type.GetProperties()
                .Select(p => new {type = p.PropertyType, name = p.Name })
                .ToArray();
        }
        public int Insert(Object T)
        {
            var type = T.GetType();
            // see previous method
        }
    }
