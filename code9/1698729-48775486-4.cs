    public interface ICommand { }
    public interface ICommand<TResult> : ICommand { }
    public interface ICommandHandler<in TCommand>
        where TCommand : class, ICommand
    {
        Task Execute(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
    public interface ICommandHandler<in TCommand, TResult> : ICommandHandler<TCommand>
        where TCommand : class, ICommand<TResult>
    {
        Task<TResult> GetResult(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
