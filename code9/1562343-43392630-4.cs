    public void UpdatePPMORecursively(Project project, string ppmo)
    {
    	if (project.PPMOProjectID == null)
    	{
    		project.PPMOProjectID = ppmo;
    	}
    
    	var childrenProjects = db.Projects.Where(c => c.AC_ParentProject_ID == project.ID).ToList();
    	if (childrenProjects.Count() == 0)
    	{
    		return;
    	}
    
    	foreach (var childProject in childrenProjects)
    	{
    		UpdatePPMORecursively(childProject, project.PPMOProjectID);
    	}
    }
