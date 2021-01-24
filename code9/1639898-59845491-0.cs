public class OperationsOrderingFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument openApiDoc, DocumentFilterContext context)
    {
        Dictionary<KeyValuePair<string, OpenApiPathItem>,int> paths = new Dictionary<KeyValuePair<string, OpenApiPathItem>, int>();
        foreach(var path in openApiDoc.Paths)
        {
            OperationOrderAttribute orderAttribute = context.ApiDescriptions.FirstOrDefault(x=>x.RelativePath.Replace("/", string.Empty)
                .Equals( path.Key.Replace("/", string.Empty), StringComparison.InvariantCultureIgnoreCase))?
                .ActionDescriptor?.EndpointMetadata?.FirstOrDefault(x=>x is OperationOrderAttribute) as OperationOrderAttribute;
            if (orderAttribute == null)
                throw new ArgumentNullException("there is no order for operation " + path.Key);
            int order = orderAttribute.Order;
            paths.Add(path, order);
        }
        var orderedPaths = paths.OrderBy(x => x.Value).ToList();
        openApiDoc.Paths.Clear();
        orderedPaths.ForEach(x => openApiDoc.Paths.Add(x.Key.Key, x.Key.Value));
    }
}
then the attribute would be 
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class OperationOrderAttribute : Attribute
{
    public int Order { get; }
    public OperationOrderAttribute(int order)
    {
        this.Order = order;
    }
}
the registration of the filter in swagger would be 
services.AddSwaggerGen(options =>
{
   options.DocumentFilter<OperationsOrderingFilter>();
}
and an example of a controller method with the attribute would be:
[HttpGet]
[OperationOrder(2)]
[Route("api/get")]
public async Task<ActionResult> Get(string model)
{
   ...
}
