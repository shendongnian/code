    private void ProcessMutationEntity<TEntity>(TEntity entity)
        where TEntity : IEntity, IMutation<TEntity>
    {
        entity.Mutations.Add(new Mutation<TEntity> { EntityId = entity.Id, Entity = entity});
    }
