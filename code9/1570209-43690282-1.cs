    public class Local
    {
        public Locale LocalAttr { get; set; }
        public IList<DateTime> FechaInstalacion { get; set; }
        public bool theCheckbox { get; set; }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult IndexAsset(string chkName)
        {
            IList<Local> listOfViewModels = FactoredOut(bool.Parse(chkName));
            return View(listOfViewModels);
        }
        public ActionResult IndexAsset(bool verBajas = false)
        {
            IList<Local> listOfViewModels = FactoredOut(verBajas);
            return View(listOfViewModels);
        }
        IList<Local> FactoredOut(bool verBajas)
        {
            //instead of faroutEntities9, use the copy and paste item your copied in previous step
            using (faroutEntities9 db = new faroutEntities9())
            {
                var locales = db.Locales.Include(l => l.Estado1).Include(l => l.Proveedor1).
                Where(l => l.Proveedor1.Nombre == "PDSUY");
                if (verBajas)
                {
                    locales = db.Locales.Include(l => l.Estado1).Include(l => l.Proveedor1).
                        Where(l => l.Proveedor1.Nombre == "PDSUY").Where(l => l.Estado1.State != "Bajas");
                }
                else if (verBajas == false)
                {
                    locales = db.Locales.Include(l => l.Estado1).Include(l => l.Proveedor1).
                        Where(l => l.Proveedor1.Nombre == "PDSUY");
                }
                IList<Local> listOfViewModels = new List<Local>();
                var list = locales.ToList();
                Local localView = new Local { LocalAttr = list[0] };
                localView.FechaInstalacion = new List<DateTime>();
                localView.FechaInstalacion.Add(DateTime.Now);
                localView.FechaInstalacion.Add(DateTime.Parse("12/12/12"));
                listOfViewModels.Add(localView);
                if (list.Count > 1)
                {
                    var list2 = locales.ToList();
                    Local localView2 = new Local { LocalAttr = list[1] };
                    localView2.FechaInstalacion = new List<DateTime>();
                    localView2.FechaInstalacion.Add(DateTime.Now);
                    localView2.FechaInstalacion.Add(DateTime.Parse("12/12/12"));
                    listOfViewModels.Add(localView2);
                }
                return listOfViewModels;
            }
        }
