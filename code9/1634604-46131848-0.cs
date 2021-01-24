    public class SmsUsersController : ApiController
    {
        private Context db = new Context();
        // GET: api/SmsUsers
        public IQueryable<SmsUser> GetSmsUsers()
        {
            return db.SmsUsers;
        }
    }
