    public interface ICancelableFooService : IFooService
    {
        Task CancelAsync();
    }
    public class CancelableFooService : ICancelableFooService
    {
        private readonly IFooService _foo_service;
        private List<Task> _createdtasks = new List<Task>();
        private CancellationTokenSource _cts = new CancellationTokenSource();
        public CancelableFooService(IFooService foo_service)
        {
            _foo_service = foo_service;
        }
        public async Task CancelAsync()
        {
            _cts.Cancel();
            await Task.WhenAll( _createdtasks );
            _cts = new CancellationTokenSource();
        }
        public Task DoAsync( CancellationToken cancellationToken )
        {
            var cts = CancellationTokenSource.CreateLinkedTokenSource( _cts.Token, cancellationToken );
            var token = cts.Token;
            var task = _foo_service.DoAsync( token );
            _createdtasks.Add( task );
            return task;
        }
    }
