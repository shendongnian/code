    public class ReChronoController : Controller
    {
        ...
        public ActionResult Index(string responsegroup = "", string responsible = "", int week = 0, int year = 0)
        {
           ...
           var model = _reChronoDb.WeekRows.Include(w => w.Days).ToList();
           ...
        }
    }
