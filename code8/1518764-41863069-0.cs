    public string Insert(Person entity)
    {
    	uow.Repository.Add(entity);	//public Repository object in unit of work which might be wrong
    	Response responseObject = uow.Save();
    	string id = entity.Id;	//gives the newly generated Id
    	return id;
    }
