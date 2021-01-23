	public Task Invoke(HttpContext context)
	{
		_unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
		   //Some checks            
			var apiKey = context.Request.Headers["X-ApiKey"][0];
			var clientApp = _unitOfWork.ClientApplicationsRepository.Items.FirstOrDefault(s => s.ApiKey == apiKey);
		 //Some other code...
		return _next(context);
	}
