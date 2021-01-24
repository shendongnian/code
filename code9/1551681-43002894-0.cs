    public class TableNameController : Controller
    {
        ...
        private string userIdentity;
        public TableNameController() {
            userIdentity = HttpContext.User.Identity.Name.Split('\\')[1].Replace(".", " ");
        }
        ...
