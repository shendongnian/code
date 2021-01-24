	public void OperationAsync(Action<BaseResult> callback)
	{
		try
		{
			var r = new BaseResult();
			using (var proxy = new WebServiceClient<T>(_fullURL))
			{
				try
				{
					r.Value = proxy.Channel.ExecuteOperation(SecurityToken());
				}
				catch (Exception ex)
				{
					r.Error = ex;
				}
			}
			if (callback != null)
			{
				callback(r);
			}
		}
		catch (Exception ex)
		{
			FileManager.Log(ex);
		}
	}
