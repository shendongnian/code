    public class MyController : Controller
    {
        private readonly MyAppContent _myAppContent;
    
        public MyController(MyAppContent myAppContent)
        {
            _myAppContent = myAppContent;
        }
    
        public ActionResult Test(int id)
        {
            var user = _myAppContent.User.Where(u => u.Id == id).First();
                
            ...
        }
    }
