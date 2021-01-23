    public class HomeController : Controller
        {
            [HttpGet]
            public ActionResult Index()
            {
                IndexVM dataVM = new IndexVM();
                GetControlsDataSource(dataVM.Orders);
    
                return View(dataVM);
            }
    
            private static void GetControlsDataSource(OrdersVM dataVM)
            {
                List<SelectListItem> typeControlDataSource = new List<SelectListItem>();
                foreach (var en in Enum.GetValues(typeof(TypeEnum)))
                {
                    SelectListItem item = new SelectListItem();
                    item.Text = en.ToString();
                    item.Value = ((int)en).ToString();
                    typeControlDataSource.Add(item);
                }
                dataVM.TypeControlDataSource = typeControlDataSource;
            }
    
    
            [HttpPost]
            public ActionResult Pay(OrdersVM dataVM)
            {
                GetControlsDataSource(dataVM);
                if (ModelState.IsValid)
                {
                    dataVM.Info = "Info bla bla bla";
                    return PartialView("~/Views/Home/_Orders.cshtml", dataVM);
                }
                else
                {
                    return View(dataVM);
                }
    
            }
        }
