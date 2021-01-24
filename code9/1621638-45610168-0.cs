    public IHttpActionResult Add(ReportingDTO data)
    {            
    	Reporting reporting = new Reporting { ID = Guid.NewGuid(), Date = DateTime.Now };                     
    
    	foreach (Assignment assignment in data.Assignments)
    	{
    		if (assignment.AssignmentType != null)
    		{
    			assignment.AssignmentTypeID = assignment.AssignmentType.ID;
    			assignment.AssignmentType = null;
    		}
    
    		reporting.Assignment.Add(assignment);
    	}
    
    	foreach (Comment comment in data.Comments)
    	{
    		comment.ID = Guid.NewGuid();
    		comment.AssignmentID = comment.Assignment.ID;
    		comment.Assignment = null;
    		comment.ReportingID = reporting.ID;
    	}
    	
    	_db.Reporting.Add(reporting);
    	_db.Comments.AddRange(data.Comments);
    	_db.SaveChanges();
    
    	return Ok(reporting);
    }
