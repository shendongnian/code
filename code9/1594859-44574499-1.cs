    Decorator : IService
    {
         IService _service
         Public Decorator(IService service)
         {
               _service = service
         }
         public string DoWork()
         {
              //new code
              _service.DoWork()
             //new code
         }
    }
