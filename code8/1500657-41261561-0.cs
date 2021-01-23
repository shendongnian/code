	public interface ICommandBus<TCommand>  where TCommand : ICommandDtc
	{
		Task<CommandResult> SubmitAsync(TCommand command) ;
		CommandResult Submit(TCommand command) ;
	}
	
	public class CommandBus<TCommand> : ICommandBus<TCommand> where TCommand : ICommandDtc
	{
		private readonly ILifetimeScope _container;
		public CommandBus(ILifetimeScope scope)
		{
			_container = scope;
		}
		public async Task<CommandResult> SubmitAsync(TCommand command)
		{
			var commandHandler = _container.Resolve<ICommandHandler<TCommand>>();
			return await commandHandler.ExecuteAsync(command);
		}
		public CommandResult Submit(TCommand command)		
		{
			**//its worked**
				var commandHandler = _container.Resolve<ICommandHandler<IntegerationCommand>>();
			**//exception**
				var commandHandler2 = _container.Resolve<ICommandHandler<TCommand>>();
			return commandHandler2.Execute(command);
		}
	}
