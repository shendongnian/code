    namespace WebPortal.Web.Controllers
    {
        public class MenuController : Controller
        {
            [ChildActionOnly] //for ajax call to controller remove this annotation
            public ActionResult TopMenuRenderer()
            {
                //return PartialView();
                if (User.IsInRole(Role.Admin.ToString()) ||
                    User.IsInRole(Role.SuperAdmin.ToString()))
                {
                    return PartialView("~/Views/Menu/_TopMenu.cshtml");
                }
                return null;
            }
    
            [ChildActionOnly]
            public ActionResult UserMenuRenderer()
            {
                if (User.Identity.IsAuthenticated)
                    return PartialView("~/Views/Menu/_UserMenuAuthenticated.cshtml");
                else
                    return PartialView("~/Views/Menu/_UserMenuNotAuthenticated.cshtml");
            }
            [ChildActionOnly] 
            public ActionResult SideMenuRenderer()
            {
                //you could put some user checks here if you want to limit some of the loaded meny options depending on the user type.
                if (User.IsInRole(Role.Admin.ToString()) ||
                    User.IsInRole(Role.SuperAdmin.ToString()))
                {
                    return PartialView("~/Views/Menu/_SideMenu.cshtml");
                }
                return null;
            }
    }     
}
  
