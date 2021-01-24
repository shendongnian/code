    public ActionResult Edit(int ProjectID,string ProjectName,string[] ParamIDs,string[] ParamValues)
            {
                // Get project from context
                Project project = db.Projects.Where(e => e.ProjectID == ProjectID).SingleOrDefault();
                project.Name = "Hi";
    
                // Remove existing parameters
                db.ProjectParams.RemoveRange(db.ProjectParams.Where(c => c.ProjectID == ProjectID));
    
                // Add new list of parameters
                project.ProjectParams= new List<ProjectParam>();
    
                //// Update all params
                 for (int i=0;i< ParamIDs.Length;i++)
                    project.ProjectParams.Add(new ProjectParam { ParamID = Convert.ToInt32(ParamIDs[i]),ParamValue=ParamValues[i],ProjectID=ProjectID });
    
                // Save changes
                if (ModelState.IsValid)
                {
                    db.Entry(project).State = EntityState.Modified;                               
                    db.SaveChanges();
    
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");            
            }
