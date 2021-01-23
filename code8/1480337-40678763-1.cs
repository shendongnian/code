	// PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
	public Task<TodoItem> PatchTodoItem(string id, Delta<TodoItem> patch)
	{
		CheckUpdateForPrecondition();
		return UpdateAsync(id, patch);
	}
		
	private void CheckUpdateForPrecondition()
	{
		if (!Request.Headers.Contains("If-Match"))
			throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
			{
				Content = new StringContent("A pre-condition version must be supplied with Update (Header: If-Match).")
			});
	}
	
