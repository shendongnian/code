    	protected virtual void Execute<TCommand>(Action<TCommand> action, TCommand command)
		{
			UnitOfWork.Add(this);
			try
			{
				action(command);
				UnitOfWork.Commit();
				Sender.Tell(true, Self);
			}
			catch(Exception exception)
			{
				Logger.LogError("Executing an Akka.net request failed.", exception: exception);
				Sender.Tell(false, Self);
				throw;
			}
		}
