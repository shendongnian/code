    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        private MenuRepo xMenuRepo;
        public MenuController(IOptions<SqlConnectionStringsList> iopt)
        {
            xMenuRepo = new MenuRepo(iopt);
        }
    
        //POST api/menu
        [HttpPost("")]
        public IEnumerable<Menu> GetMenuItems([FromBody] MenuQuery menuq)
        {
            List<Menu> xMenuList = new List<Menu>();
            xMenuList = xMenuRepo.GetMenuItems(menuq.app_id, menuq.user_type);
            return xMenuList;
        }
    }
