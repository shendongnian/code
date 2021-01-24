    public class ResetPasswordViewModel
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string repeatNewPassword { get; set; }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (String.IsNullOrEmpty(resetPasswordViewModel.oldPassword) ||
                String.IsNullOrEmpty(resetPasswordViewModel.newPassword) ||
                String.IsNullOrEmpty(resetPasswordViewModel.repeatNewPassword)
                )
            {
                //show dialog
                ViewBag.ShowDialog = true;
            }
            return View("IndexPage2", resetPasswordViewModel);
        }
        public ActionResult IndexPage2()
        {   //start page specified in routeconfig.cs
            return View();
        }
