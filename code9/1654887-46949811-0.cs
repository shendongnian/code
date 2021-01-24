    // somewhere in a controller
	public void UpdatePerson(UpdatePersonViewModel model)
	{
		var entity = Get(model.Id);
		
		entity.Name = model.Name;
		
		Save(entity);
	}
