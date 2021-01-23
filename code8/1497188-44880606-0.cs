        public class LanguageController : Controller
        {
            public ActionResult ChangeLanguage()
            {
                if (Thread.CurrentThread.CurrentCulture.Name == "en-US")
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");
                    ViewBag.CultBtn = "En";
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    ViewBag.CultBtn = "Fr";
                }
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                HttpContext.Current.Session["culture"] = Thread.CurrentThread.CurrentCulture.Name;
                return RedirectToAction("Index", "Home");
            }
        }
