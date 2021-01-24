    // View (CSS)
    #body-bg {
        background-image: url('@ViewBag.BackgroundImage');
    }
    // Controller
    public class HomeController : Controller
    {
        // other stuff
        ViewBag.BackgroundImage = "/path/to/image.png";
        return View();
    }
