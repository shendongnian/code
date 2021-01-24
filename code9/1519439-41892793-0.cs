    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,dateCreated,dateRemoved,level,firstName,lastName,login,emailAddress,password")] User user, Task task)
        {
            user.dateCreated = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                task.userId = 2;
                task.dateAssigned = DateTime.Now;
                task.dateCreated = DateTime.Now;
                task.dateDue = DateTime.Now.AddDays(7);
                task.taskCategory = taskCategory.assigned;
                task.taskType = taskType.System_Induction;
                task.assigneeId = user.userId;
                task.taskPriority = taskPriority.Low;
                task.taskName = "Iduction to TaskManagementTool";
                task.Comments = "Please go through the following training materials:";
                task.taskStatus = taskStatus.Assigneed;
                if (ModelState.IsValid) {
                    db.Tasks.Add(task);
                    db.SaveChanges();
                                   
                
                }
               return RedirectToAction("Index");
            }
            return View(user);
        }
