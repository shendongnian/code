    public class PageElement
    {
        IPageController _controller;
        // these are your models - your controller will simply allow them to be shown with your other methods
        private PageData _data; 
        private PageData _otherData;
        public PageElement(IPageController ctrl)
        {
             _controller = ctrl;
        }
    }
    public class PageController : IPageController
    {
         IPageService _service;
         public PageController(IPageService service)
         {
              _service = service;
         }
         
         // this is what your button calls when clicked
         public void SaveAsync(object sender, SomeEventArgs args)
         {
               // the service does the actual work
              _service.SaveAsync()
         }
    }
    public class PageService : IPageService
    {
         public void SaveAsync(){ // what it does}
          
    }
