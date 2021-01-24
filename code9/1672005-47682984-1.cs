    public async Task DeleteItem<T>(int id, bool removeRow) where T : class, IBaseData
    {
    	if (removeRow)
    	{
    		GetRepo<T>().Delete(await GetRepo<T>().Single(obj => obj.Id.Equals(id)));
    	}
    	else
    	{
    		var tmp = await GetRepo<T>().Single(obj => obj.Id.Equals(id));
    		tmp.Active = false;
    	}
    	
    	await SaveChangesAsync();
    }
