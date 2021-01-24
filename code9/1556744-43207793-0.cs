    public async Task Consume(ConsumeContext<IGetEntityCommand> context)
    {
        var ids = context.Message.Ids;
        var entities = _entityService.GetAll(ids, context.Message.ExcludeDeleted); //database NHibernate call
        await
            context.RespondAsync(new GetEntityCommandResponse
            {
                Success = true,
                Entities = entities.Select(x => x.ToDTO).ToList()
            });
    }
