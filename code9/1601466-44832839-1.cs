    //You can put this in its own folder
    public class Utilites
    {
        public static List<SelectListItem> GetTableAList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem { Text = "one", Value = "1" };
            SelectListItem item2 = new SelectListItem { Text = "two", Value = "2" };
            SelectListItem item3 = new SelectListItem { Text = "three", Value = "3" };
            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            //add <select> to first item
            list.Insert(0, new SelectListItem { Text = "", Value = "" });
            return list;
        }
        public static List<SelectListItem> GetTableBList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem { Text = "one", Value = "1" };
            SelectListItem item2 = new SelectListItem { Text = "two", Value = "2" };
            SelectListItem item3 = new SelectListItem { Text = "three", Value = "3" };
            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            //add <select> to first item
            list.Insert(0, new SelectListItem { Text = "", Value = "" });
            return list;
        }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult IndexValid9(YourViewModel yourViewModel)
        {
           //you can put your breakpoint here to see user selected values
           return View(yourViewModel);
        }
        public ActionResult IndexValid9()
        {
            YourViewModel yourViewModel = new YourViewModel();
            return View(yourViewModel);
        }
