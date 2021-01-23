    void ProcessMutationEntity<TEntity, TMutation>(TEntity entity)
    	where TEntity : IEntity, IMutation<TMutation>
    	where TMutation : IEntity
    {
    	entity.Mutations.Add(new Mutation<TMutation> {  });
    }
