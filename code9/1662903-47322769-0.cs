	public class ConnectionStatus
	{
		private Subject<Unit> pending = new Subject<Unit>();
		private Subject<Unit> connected = new Subject<Unit>();
	
		public bool IsConnected { get; private set; }
	
		public ConnectionStatus(CancellationToken token, short timeoutSeconds = 15)
		{
			pending
				.Select(outer =>
					Observable.Amb(
						connected.Select(_ => true),
						Observable.Timer(TimeSpan.FromSeconds(timeoutSeconds)).Select(_ => false)))
				.Switch()
				.Subscribe(isConnected => IsConnected = isConnected, token);
		}
	
		public void ConfirmConnected()
		{
			connected.OnNext(Unit.Default);
		}
	
		public void SetPending()
		{
			pending.OnNext(Unit.Default);
		}
	}
