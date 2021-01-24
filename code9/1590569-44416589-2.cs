    [Authorize]
    public class MyController : ApiController
    {
        public IEnumerable<SelectedMenu> GetAllMenus() // Resturants ID
        {
            var clientId = User.GetClientId();
        }
    }
