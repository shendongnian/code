    public class GroepController : Controller
    {
        AlinaDatabaseDataContext db = new AlinaDatabaseDataContext();
        // GET: Groep
        public ActionResult Groepen()
        {
            List<GroepModel> groepen = Mapper.Map<List<GroepenWerkvorm>,     List<GroepModel>>(db.GroepenWerkvorms.ToList());
    
            var model = new MyViewModel();
            model.list = new SelectList(groepen, "id", "Naam");
    
            return View(model);
        }
    }
