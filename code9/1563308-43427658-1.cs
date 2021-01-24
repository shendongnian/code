    public void UpsertDocument(dynamic entity)
	{
			    entity.Id = new Guid();			
			    repo.Set(new ProxyDocumentEntity(entity));
    }
