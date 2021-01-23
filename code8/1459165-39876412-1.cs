    public ActionResult Create()
    { return View(); }
    [HttpPost] 
    public ActionResult Create(Student student)
    {
         var result = _studentDb.Insert(student); 
         return View(); 
    }
