[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class SwaggerIgnoreAttribute : Attribute
{
}
internal static class StringExtensions
{
    internal static string ToCamelCase(this string value)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return char.ToLowerInvariant(value[0]) + value.Substring(1);
    }
}
public class SwaggerIgnoreFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext schemaFilterContext)
    {
        if (schema.Properties.Count == 0)
            return;
        const BindingFlags bindingFlags = BindingFlags.Public |
                                          BindingFlags.NonPublic |
                                          BindingFlags.Instance;
        var memberList = schemaFilterContext.SystemType
                            .GetFields(bindingFlags).Cast<MemberInfo>()
                            .Concat(schemaFilterContext.SystemType
                            .GetProperties(bindingFlags));
        var excludedList = memberList.Where(m =>
                                            m.GetCustomAttribute<SwaggerIgnoreAttribute>()
                                            != null)
                                     .Select(m =>
                                         (m.GetCustomAttribute<JsonPropertyAttribute>()
                                         ?.PropertyName
                                         ?? m.Name).ToCamelCase());
        foreach (var excludedName in excludedList)
        {
            if (schema.Properties.ContainsKey(excludedName))
                schema.Properties.Remove(excludedName);
        }
    }
}
and in `Startup.cs`:
services.AddSwaggerGen(c =>
{
    ...
    c.SchemaFilter<SwaggerIgnoreFilter>();
    ...
});
