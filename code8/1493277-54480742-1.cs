[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class SwaggerIgnoreAttribute : Attribute
{
}
public class SwaggerExcludeFilter : ISchemaFilter
{
    public void Apply(Microsoft.OpenApi.Models.OpenApiSchema schema, SchemaFilterContext schemaFilterContext)
    {
        if (schema.Properties.Count == 0)
            return;
        const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        var memberList = schemaFilterContext.SystemType
                        .GetFields(bindingFlags).Cast<MemberInfo>()
                        .Concat(schemaFilterContext.SystemType
                                    .GetProperties(bindingFlags));
        var excludedMemberNames = memberList
                                        .Where(m =>
                                            m.GetCustomAttribute<SwaggerIgnoreAttribute>()
                                            != null)
                                        .Select(m =>
                                            {
                                                var j = m.GetCustomAttribute<JsonPropertyAttribute>();
                                                if (j == null || j.PropertyName == null)
                                                    return m.Name;
                                                return j.PropertyName;
                                            });
        foreach (var excludedMemberName in excludedMemberNames)
        {
            if (schema.Properties.ContainsKey(excludedMemberName))
                schema.Properties.Remove(excludedMemberName);
        }
    }
}
and in `Startup.cs`:
services.AddSwaggerGen(c =>
{
    ...
    c.SchemaFilter<SwaggerExcludeFilter>();
    ...
});
