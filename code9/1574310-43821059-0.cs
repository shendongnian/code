    namespace WebApplication1.Controllers
    {
    public class UsersController : BaseApiController
    {
        public IEnumerable<Users> Get()
        {
            List<Users> a = new List<Users>();
            Users u = new Users();
            u.ID = 99;
            u.FULLNAME = "XXX";
            u.USER = "XXX";
            u.PASSWORD = "XXX";
            a.Add(u);
            return a;
        }
