    public class HomeController : Controller
    {
        public ActionResult AddComplianceForm(string TemplateName)
        {
            Assembly assembly = Assembly.Load("Testy20161006");                     //assembly name
            Type t = assembly.GetType("Testy20161006.Templates." + TemplateName);   //namespace + class name
            Object obj = (Object)Activator.CreateInstance(t);
            return View();
        }
