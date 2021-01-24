    public class EnumFilter : ISchemaFilter
    {
        public void Apply(Schema model, SchemaRegistry schemaRegistry, Type type)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            if (schemaRegistry == null)
            {
                throw new ArgumentNullException("schemaRegistry");
            }
            if (IsEnum(type, out var enumName))
            {
                model.vendorExtensions.Add("x-ms-enum", new
                                                  {
                                                      name = enumName ?? type.Name,
                                                      modelAsString = false
                                                  });
            }
        }
        public static bool IsEnum(Type t, out string enumName)
        {
            if (t.IsEnum)
            {
                enumName = t.Name;
                return true;
            }
            Type u = Nullable.GetUnderlyingType(t);
            enumName = u?.Name;
            return (u != null) && u.IsEnum;
        }
    }
