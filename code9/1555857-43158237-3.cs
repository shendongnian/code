    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new PreferencesShoppingCartViewModel
            {
                CartItemPreferences = new List<CartItemPreference>
                {
                    new CartItemPreference { CartItem = new CartItem { Sample = "Sample 1"}},
                    new CartItemPreference { CartItem = new CartItem { Sample = "Sample 2"}}
                },
                PreferenceOptions = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Option 1", Value = "1"},
                    new SelectListItem {Text = "Option 2", Value = "2"},
                    new SelectListItem {Text = "Option 3", Value = "3"}
                }
            };
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(PreferencesShoppingCartViewModel model)
        {
            // Do something
    
            return View(model);
        }
    }
