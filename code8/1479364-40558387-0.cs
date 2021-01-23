    public class UserController : Controller
    {
        public object Index(int? page)
        {
            var pageIndex = (page ?? 1) - 1; //MembershipProvider expects a 0 for the first page
            var pageSize = 10;
            int totalUserCount; // will be set by call to GetAllUsers due to _out_ paramter :-|
    
            var users = Membership.GetAllUsers(pageIndex, pageSize, out totalUserCount);
            var usersAsIPagedList = new StaticPagedList<MembershipUser>(users, pageIndex + 1, pageSize, totalUserCount);
    
            ViewBag.OnePageOfUsers = usersAsIPagedList;
            return View();
        }
    }
