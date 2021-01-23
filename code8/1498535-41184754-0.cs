    Public ActionResult Index()
    {
         var student = new Student();
         student.CreateOn = DateTime.Now;         
         return View(student);  
    }
