    public class ColumnAttributeTypeMapper : FallbackTypeMapper
    {
        public ColumnAttributeTypeMapper(object instance)
            : this (instance.GetType())
        {
        }
        public ColumnAttributeTypeMapper(Type T)
            : base(new SqlMapper.ITypeMap[]
                {
                    new CustomPropertyTypeMap(
                       T,
                       (type, columnName) =>
                           type.GetProperties().FirstOrDefault(prop =>
                               prop.GetCustomAttributes(false)
                                   .OfType<ColumnAttribute>()
                                   .Any(attr => attr.Name == columnName)
                               )
                       ),
                    new DefaultTypeMap(T)
                })
        {
        }
    }
