    public class CoursesController : Controller
    {
        private readonly LakeViewContext db;
        public CoursesController(LakeVieContext db)
        {
            this.db = db;
        }
        ...
