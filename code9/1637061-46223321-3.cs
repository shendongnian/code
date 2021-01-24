	interface IRequest { }
	interface IResponse { }
	interface IReceiver<in TRequest, out TResponse>
		where TRequest : IRequest
		where TResponse : IResponse
	{
		TResponse Action(TRequest request);
	}
	interface ICommand<out TRequest, out TResponse>
	{
	}
	abstract class AbstractCommand<TRequest, TResponse> : ICommand<TRequest, TResponse>
		where TRequest : IRequest	
		where TResponse : IResponse
	{
		protected IReceiver<TRequest, TResponse> _receiver;
		public AbstractCommand(IReceiver<TRequest, TResponse> receiver)
		{
			_receiver = receiver;
		}
		public abstract TResponse Execute(TRequest request);
	}
	class CommandProcessor
	{
		IList<ICommand<IRequest, IResponse>> _supportedCommands = new List<ICommand<IRequest, IResponse>>();
		public CommandProcessor()
		{
		}
		void AddSupportedCommand(ICommand<IRequest, IResponse> item)
		{
			_supportedCommands.Add(item);
		}
		void SetupSupportedCommands()
		{
			AddSupportedCommand(new SumCommand(new SumReceiver()));
		}
	}
