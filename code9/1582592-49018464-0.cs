    public class FileOperation : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
    		if (operation.OperationId.ToLower() == "apifileget")
    		{
    			operation.Produces = new[] { "application/octet-stream" };
    			operation.Responses["200"].Schema = new Schema { Type = "file", Description = "Download file"};
    		}
    	}
    }
    
    //In the startup...
    services.AddSwaggerGen(c =>
    {
    	//missing code...
    	c.OperationFilter<FileOperation>();
    });
