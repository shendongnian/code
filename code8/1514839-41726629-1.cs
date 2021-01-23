     public class SakilaController : Controller
            {
    
                public JsonResult Index()
                {
                  return view();
                }
                public JsonResult GetData()
                {
                    List<ActorModel> actormodel = new List<ActorModel>();
                    using (var context = new sakilaEntities())  
                    {
    
                        List<actor> b = context.actors.ToList();
                        actormodel.Add(new ActorModel()
                        {id = 1,
                         f_name = "MS",
                         l_name = "Vivek",
                         last_update = DateTime.Now});
                     }
            return Json(actormodel.ToList(), JsonRequestBehavior.AllowGet);
    
           }
         }
