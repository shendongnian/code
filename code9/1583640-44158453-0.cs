    //after you refactor it more you will see that this check is actually not needed.
    if (entity != null)
    {
    	//Called entity but represents a Tournament
    	//so the check is to see if the T has more seats than the current attending users
    	if(entity.Seats.Count > entity.Users.Count)
    	{
    		//this was to check if the user is already in the attending users
    		//if(entity.Users.All(e => user != null && e.UserId != user.UserId))
    		
    		var userInSeats = entity.Users.Where(x=>x.UserId == user.UserId).SingleOrDefualt();
    		if(userInSeats == null )
    		{
    			// Add user
    			entity.Users.Add(user);
    
    			// Save changes
    			_dbContext.SaveChanges();
    
    			// Commit transaction
    			transaction.Commit();
    		}
    	}
    }
