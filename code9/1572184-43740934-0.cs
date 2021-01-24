    public class UpdateController : Controller
    {
        DemoDatabaseEntities db = new DemoDatabaseEntities();
        Student _bal = new Student();
        / GET: Update
        public ActionResult Index()
        {
            Student_Mast model = new Student_Mast();
            model = _bal.getStudentByID();
            db.Entry(model ).State = EntityState.Modified
    
            model.First_Name = "Hardik";
            model.Last_Name = "Gondalia";
            db.SaveChanges();
            return View();
        }
    }
