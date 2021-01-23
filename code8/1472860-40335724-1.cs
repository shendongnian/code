    public interface IRepository {
        Center GetCenter(Guid guid);
    }
    public class Repository : IRepository {
        //...other code removed for brevity
    }
    [Authorize]
    public class HomeController : Controller {
        private IRepository repository;
        public HomeController(IRepository repository) {
            this.repository = repository;
        }
        [Authorize(Roles = "ECLS Center Data Manager, ECLS Center Administrator,ECLS Center Data Viewer, ECLS Center Data Entry")]
        //[RequireHttps]  // Enable for production
        public ActionResult Index(Guid? CenterId) {
            //----------------------------------------
            // Remove references to previous patients
            //----------------------------------------    
            Session.Remove("Patient");
            Session.Remove("PatientSummary");
            Session.Remove("Run");
            Session.Remove("RunDetail");
            Session.Remove("Addendum");
            // if user have this session then he will get edit forms. // Yes if Add new
            Session.Remove("AddNewMode");
            Session.Remove("AddNewRunId");
            Center center;
            if (CenterId.GetValueOrDefault() == Guid.Empty) {
                center = Session["Center"] as Center;
                Contract.Assert(center != null);
            } else { // set center by selected centerId from dropdownlist
                center = repository.GetCenter(CenterId.Value);
                Session["Center"] = center;
                center = Session["Center"] as Center;
                Contract.Assert(center != null);
            }
            ViewBag.RunCounts = Session["RunCounts"];
            ViewBag.ChartSummaries = Session["ChartSummaries"];
            return View(new QuickAdd());
        }
    }
