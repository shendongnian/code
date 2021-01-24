      // GET: Locals/Create
        public ActionResult Create()
        {
            Resource resource = new Resource();
            List<ResourceType> resourceType;
            
            using (yourcontext db = new yourcontext())
            {
                resourceType = db.ResourceType.ToList(); //fill your list with the resourceTypes that are in your database
                
            }
    
            CreateResourceViewModel vm = new CreateResourceViewModel(resource,resourceType); //create a new viewmodel and give it the parameters necesary that we created
    
    
            return View(vm);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateResourceViewModel vm)
        {
            using (yourcontext db = new yourcontext())
            {
                if (ModelState.IsValid)
                {
                    try {
                        vm.Resource.Type = db.ResourceTpe.Find(vm.IdResourceType); //using the ID selected in the view find it in the database
    
                        db.Resources.Add(vm.Resource);
                        db.SaveChanges();
                        return RedirectToAction("Index");
    
                    }
                    catch (Exception e)
                    {
                        e.Message();
                    }
                }
    
                return View(vm);
            }
        }
