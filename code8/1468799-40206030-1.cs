    public class UserController : Controller
    {
      private readonly IUserService userService;
      public UserController(IUserService userService)
      {
        this.userService = userService;
      }
      public ActionResult Details(int id)
      {
        var userDto= this.userService.GetUser(id);
        return View(userDto);
      }
    }
