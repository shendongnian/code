	public async Task<ReaderEvent> WaitForReaderAsync(int PlaceId, TimeSpan waitFor)
	{
		return await
			_OnReaderEvent
				.Where(r => r.PlaceId == PlaceId)
				.Buffer(waitFor, 1)
				.Select(xs => xs.FirstOrDefault())
				.FirstOrDefaultAsync()
				.ToTask();
	}
