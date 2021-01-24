    public abstract class EntityMapperBase
    {
        protected void Map(string columnName, Func<object> func)
        {
            _mappings.Add(columnName, func);
        }
    
        protected object GetValueForColumn(string columnName)
        {
           return _mapping[columnName]();
        }
    }
    
    public class PersonMap: EntityMapperBase
    {
        public string Name { get; set; }
    
        public PersonMap()
        {
            Map(() => this.Name);           
        }
    }
