    public class Controller
    {
         private readonly IService _service;
    
         public Controller(IService service)
         {
             _service = service;
         }
    
         public async Task<IHttpActionResult> Create(string content)
         {
             var result = await _service.method(content);
             if (!result.Succeeded)
             {
                return this.GetErrorResult(result);
             }
             return Ok();
         }
    }
