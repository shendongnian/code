	private void InformClient(ClientInfo clientInfo)
	{
		var subscribers = this._subscriberRepository.GetAll();
		foreach (var subscriber in subscribers)
		{
			try
			{
				if (subscriber.Callback.FireInformClient(clientInfo));
				{
					//If subscriber not reachable, unsubscribe it
					this._subscriberRepository.Unsubscribe(subscriber.ClientId);
				}
			}
			catch (Exception exception)
			{
				//If subscriber not reachable, unsubscribe it
				this._subscriberRepository.Unsubscribe(subscriber.ClientId);
				Log.Error(nameof(InformClient), exception);
			}
		}
	}
