    public class SomeController : Controller
        
        [HttpGet]
        public ActionResult LoadData()
        {
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                products = session.Query<Product>().ToList(); //  Querying to get all the books
            }
        
            return Json(new {data=product},
                        JsonRequestBehavior.AllowGet);
        }
