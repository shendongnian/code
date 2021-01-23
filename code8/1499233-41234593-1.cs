    public class MyCustomModuleController : DnnApiController
    {   
        public HttpResponseMessage GetFoo(int id)
        {
            try
            {
               ...
            }
            catch (Exception ex)
            {
                DotNetNuke.Services.Exceptions.Exceptions.LogException(ex); 
            }
        }
    }
