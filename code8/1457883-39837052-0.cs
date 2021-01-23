    [HttpPost("group")]
    public async Task<IActionResult> CreateGroup([FromBody] ProjectGroupModel pro)
    {
        var dbProject = await _context.Project
            .Include(p=>p.ProjectEmployees)
            .FirstAsync(p => p.ProjectId == pro.ProjectId);
        
    	foreach (var old in dbProject.ProjectEmployees)
    		{
    			_context.ProjectEmployee.Remove(old);
    		}
    		
    	dbProject.ProjectEmployees.Clear();
    			
        foreach (var emp in pro.ProjectEmployees)
            {
                dbProject.ProjectEmployees.Add(new ProjectEmployee()
                {
                    UserId = emp.UserId
                });
            }
    
        await _context.SaveChangesAsync();
    
        return Ok();
    }
