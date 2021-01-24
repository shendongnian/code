    string AC_ProjectID = "MP1"; // you might be getting this value from somewhere else and not declaring it like this
    string parentPPMOID = "889"; // the value which you are updating
    var masterParent = db.Projects.FirstOrDefault(p => p.ID == AC_ProjectID); //get the master parent itself
    masterParent.PPMOProjectID = parentPPMOID;
    var parentProjects = db.Projects.Where(m => m.ParentID == AC_ProjectID).ToList();
    
    foreach(var parentProject in parentProjects)
    {
    	if(parentProject.PPMOProjectID == null)
    	{
            // assign the PPMOProjectID to the parent
    		parentProject.PPMOProjectID = masterParent.PPMOProjectID;
    	}
    	var childProjects = db.Projects.Where(c => c.ParentID == parentProject.ID).ToList();
    	foreach(var childProject in childProjects) 
    	{
    		if(childProject == null) 
    		{
                //assign the child PPMOProjectID with the parent PPMOProjectID since it already was set in line 11 (of this code snippet)
    			childProject.PPMOProjectID = parentProject.PPMOProjectID;			
    		}		
    	}	
    }
    
    //saving logic here..
