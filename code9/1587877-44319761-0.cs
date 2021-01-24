    public ActionResult DetailTasks(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
    
            Project project = db.Projects.Find(id);
    
            if (project == null)
            {
                return HttpNotFound();
            }
    
            var tasks = project.TaskCollection.ToList();
    
            ViewBag.tasks = tasks;
            return View(project);
    
        }
