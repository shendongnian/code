    public class TestController : Controller
        {
            ConuntryContext db = new ConuntryContext();
    
            public ActionResult Index()
            {
                db.Country.Add(new Country { 
                    CountryId = 1,
                    CountryName = "India"
                });
    
                db.Country.Add(new Country
                {
                    CountryId = 2,
                    CountryName = "USA"
                });
    
                db.Country.Add(new Country
                {
                    CountryId = 3,
                    CountryName = "UK"
                });
    
                db.SaveChanges();
    
                var countries = db.Country.ToList();
                ViewBag.countries = new SelectList(countries, "CountryId", "CountryName");
                return View();
            }
    
            [HttpPost]
            public ActionResult Action(Country country)
            {
                var countries = db.Country.ToList();
                ViewBag.countries = new SelectList(countries, "CountryId", "CountryName");
                ViewBag.selectedValue = db.Country.Where(a => a.CountryId == country.CountryId).Select(a => a.CountryName).SingleOrDefault();
                return View();
            }
    }
