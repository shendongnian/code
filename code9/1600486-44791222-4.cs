    //You can put this in a model folder
    public class FieldViewModel
    {
        public FieldViewModel()
        {
            TableAList = Utilites.GetTableAList();
            TableBList = Utilites.GetTableBList();
        }
        public List<SelectListItem> TableAList { get; set; }
        public List<SelectListItem> TableBList { get; set; }
        public int SelectedA { get; set; }
        public int SelectedB { get; set; }
    }
    //You can put this in its own folder
    public class Utilites
    {
        public static List<SelectListItem> GetTableAList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                using (BreazEntities31 entity = new BreazEntities31())
                {
                    entity.TableAs.
                        OrderBy(r => r.Text).ToList().ForEach(r => list.Add(
                        new SelectListItem { Text = r.Text, Value = r.Value.ToString() }));
                }
            }
            catch (Exception e)
            { }
            //add <select> to first item
            list.Insert(0, new SelectListItem { Text = "", Value = "" });
            return list;
        }
        public static List<SelectListItem> GetTableBList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                using (BreazEntities31 entity = new BreazEntities31())
                {
                    entity.TableBs.
                        OrderBy(r => r.Text).ToList().ForEach(r => list.Add(
                        new SelectListItem { Text = r.Text, Value = r.Value.ToString() }));
                }
            }
            catch (Exception e)
            { }
            //add <select> to first item
            list.Insert(0, new SelectListItem { Text = "", Value = "" });
            return list;
        }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult IndexValid9(FieldViewModel fieldViewModel)
        {
           //put breakpoint here to see selected values from both ddl, interrogate fieldViewModel
           return View();
        }
        public ActionResult IndexValid9()
        {
            FieldViewModel fieldViewModel = new FieldViewModel();
            return View(fieldViewModel);
        }
