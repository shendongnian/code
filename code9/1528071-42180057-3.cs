		public async Task<IDictionary<long, int>> GetCountsAsync(CancellationToken cancellationToken)
		{
			ContinuationToken continuationToken = null;
			var actors = new Dictionary<long, int>();
			do
			{
				var page = await this.StateProvider.GetActorsAsync(100, continuationToken, cancellationToken);
				foreach (var actor in page.Items)
				{
					var count = await this.StateProvider.LoadStateAsync<int>(actor, "count", cancellationToken);
					actors.Add(actor.GetLongId(), count);
				}
				continuationToken = page.ContinuationToken;
			}
			while (continuationToken != null);
			return actors;
		}
