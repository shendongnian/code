	private Dictionary<string, object> GetSomeData(string id)
	{
		var result = FetchComponentAsync(id).Result;
		DoSomethingSyncWithResult(result);
		return result;
	}
	private async Task<Dictionary<string, object>> FetchComponentAsync(int id)
	{
		using (AuthorizationManager.Instance.AuthorizeAsInternal())
		{
			var uow = UnitOfWork.Current;
			var source = await uow.Query("Components")
				.Where("Id = @id", new { id })
				.PrepareAsync();
			var single = await source.SingleOrDefaultAsync();
			return single.ToDictionary();
		}
	}
