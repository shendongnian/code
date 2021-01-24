    public bool Update(UserBlueRayList item)
        {
            var userBRList = _db.UserBlueRayLists.FirstOrDefault(x => x.Id == item.Id);
            if(userBRList != null)
            {
    	        _dbContext.Entry(userBRList).CurrentValues.SetValues(item); 
                return return _dbContext.SaveChanges() > 0;
            }
            return false;
        }
