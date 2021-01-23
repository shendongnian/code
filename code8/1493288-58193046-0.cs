[AttributeUsage(AttributeTargets.Property)]
public class SwaggerExcludeAttribute : Attribute { }
Create a SchemaFilter which will be used by swagger to generate the API Model Schema
public class SwaggerExcludeFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!(context.ApiModel is ApiObject))
        {
            return;
        }
        
        var model = context.ApiModel as ApiObject;
        
        if (schema?.Properties == null || model?.ApiProperties == null)
        {
            return;
        }
        var excludedProperties = model.Type
                .GetProperties()
                .Where(
                    t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null
                );
        
        var excludedSchemaProperties = model.ApiProperties
               .Where(
                    ap => excludedProperties.Any(
                        pi => pi.Name == ap.MemberInfo.Name
                    )
                );
        
        foreach (var propertyToExclude in excludedSchemaProperties)
        {
            schema.Properties.Remove(propertyToExclude.ApiName);
        }
    }
}
Then, inside the ```Startup.cs``` file add this to the swagger configuration
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.SchemaFilter<SwaggerExcludeFilter>();
});
You can now use the custom attribute on a property that you want to exclude from the API Mode Shema like this
public class MyApiModel
{
    [SwaggerExclude]
    public Guid Token { get; set; }
	
	public int Id { get; set; }
	
	public string Name { get; set; }
}
