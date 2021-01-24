	public IObservable<Response> SendNetworkRequestObservable(string requestType)
	{
		return
			Observable
				.Create<Response>(observer =>
				{
					Action<Response> callback = null;
					var callbackQuery =
						Observable
							.FromEvent<Response>(h => callback += h, h => callback -= h)
							.Take(1);
					var subscription = callbackQuery.Subscribe(observer);
					this.SendNetworkRequest(requestType, callback);
					return subscription;
				});
	}
