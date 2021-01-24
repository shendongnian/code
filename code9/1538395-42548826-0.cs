		protected override async Task OnActivateAsync()
		{
			ActorEventSource.Current.ActorMessage(this, "Actor activated.");
			var initialized = await  this.StateManager.ContainsStateAsync("initalized");
			if (!initialized) await Initialize();
		}
		private async Task Initialize()
		{
			ActorEventSource.Current.ActorMessage(this, "Actor initialized.");
			await this.StateManager.AddStateAsync("initialized", true);
		}
