    public class MyCustomModuleController : DnnApiController
    {
        private DotNetNuke.Instrumentation.ILog Logger { get; set; }
    
        public MyCustomModuleController()
        {
            Logger = DotNetNuke.Instrumentation.LoggerSource.Instance.GetLogger(this.GetType());
        }
    
        public HttpResponseMessage GetFoo(int id)
        {
            try
            {
               ...
            }
            catch (Exception ex)
            {
                Logger.Error(ex); 
            }
        }
    }
