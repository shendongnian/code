		protected override async Task RunAsync(CancellationToken cancellationToken)
		{
			var actorProxyFactory = new ActorProxyFactory();
			long iterations = 0;
			while (true)
			{
				cancellationToken.ThrowIfCancellationRequested();
				iterations += 1;
				var actorId = iterations % 10;
				var count = Environment.TickCount % 100;
				var manyfoldActor = actorProxyFactory.CreateActorProxy<IManyfoldActor>(new ActorId(actorId));
				manyfoldActor.SetCountAsync(count, cancellationToken).ConfigureAwait(false);
				ServiceEventSource.Current.ServiceMessage(this.Context, $"Set count {count} on {actorId} @ {iterations}");
				await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);
			}
		}
