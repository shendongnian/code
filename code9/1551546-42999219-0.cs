    public Task<int> SaveItemAsync(Model person)
		{
			if (person != null)
			{
				if (person.ID != 0)
				{
					return _database.UpdateAsync(person);
				}
				else
				{
					return _database.InsertAsync(person);
				}
			}
			else 
			{
				return _database.InsertAsync(person);
			}
		}
