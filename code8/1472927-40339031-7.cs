    public Task<IActionResult> RegisterTenant(
        [FromBody]RegisterTenantCommand command,
        [FromService]ICommandHandler<RegisterTenantCommand> registerTenantHandler
    )
    {
        registerTenantHandler.Handle(command);
    }
