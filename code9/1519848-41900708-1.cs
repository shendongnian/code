    public Task<bool> MoveNextAsync(CancellationToken cancellationToken){ 
    try
	{
		return Task.FromResult(_inner.MoveNext());
	}
	catch (Exception ex)
	{
		return Task.FromResult(false);
	}}
