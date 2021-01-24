	public ActionResult GetUserList(string searchRequest)
	{
		try
		{                            
			if (searchRequest != null)
			{
				IQueryable<User> query; 
				
				if (searchRequest == "All")
				{
					query = db.user.AsQueryable(); // here i want to write select query but how i don't know
				}
				else if (searchRequest == "Flight") 
				{
					UserList = db.user.Where(t => t.type_id == (int)ServiceTypeEnum.Flight);
				}  
				
                if(query != null)
                {
					var list = query.Select(e=> new UserDto
					{
						Id = e.Id,
						Name = e.Name
						//Other properties
					}).ToList();
					return Json(new { data = list });
                }	
			}                                       
			
	   }
	   catch (Exception ex)
	   {
		   throw;
	   }
	   return Json(null);
	}
