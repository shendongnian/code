    public class SomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new SomeViewModel();
            var entities = new DomeinnaambeheerEntities1();
            //change the below query accordingly
            var joinQuery = from d in entities.Domeinnaam
                            join x in entities.X on d.DomeinnaamId equals x.XId
                            join y in entities.Y on d.DomeinnaamId equals y.YId
                            into dom
                            select new { Domeinnaam = dom };
            viewModel.Domeinnaam = joinQuery;
            return View(viewModel);
        }
    }
