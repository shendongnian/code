     public class CrudController: Controller  
        {  
            TrialsDBEntities tdb;  
            Sales sa = new Sales();  
            public ActionResult Index()  
            {  
                return View();  
            }  
            public JsonResult GetStudents()  
            {  
                try  
                {  
                    var result = <data list>
                    return Json(result, JsonRequestBehavior.AllowGet);                    
                }  
                catch (Exception ex)  
                {  
                    //Log ex.Message 
                }  
            }
        }  
