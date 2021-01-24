		public Task<int> GiveANumberAsync()
		{
			return Task.FromResult(12);
		}
		int result = await GiveANumberAsync();
