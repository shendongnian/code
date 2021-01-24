    public class HomeController : SqlConnectionApiController 
    {
        public HomeController()
        {
            var connection = base.GetConnection();
        }
    }
