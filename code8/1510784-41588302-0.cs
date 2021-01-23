     [HttpGet]
     public ActionResult Create(int professorId) {
         var vm = new  UniversityApp.Models.Student {
             professorId = professorId 
         }
         // best practice: always provide the name of the View you want to render
         return View("Create", vm); 
     }
