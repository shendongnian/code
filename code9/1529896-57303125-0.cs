    public class FileDownloadOperation : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var rt = context.MethodInfo.ReturnType;
            if (rt == typeof(Stream) || 
                rt == typeof(Task<Stream>) || 
                rt == typeof(FileStreamResult) || 
                rt == typeof(Task<FileStreamResult>))
            {
                operation.Responses["200"] = new Response
                {
                    Description = "Success", Schema = new Schema {Type = "file"}
                };
                operation.Produces.Clear();
                operation.Produces.Add("application/octet-stream");
            }
        }
    }
