	[Route("create-license/{licenseKey}")]
	public async Task<LicenseDetails> CreateLicenseAsync(string licenseKey, CreateLicenseRequest license)
	{
		try
		{
			// ... controller-y stuff
			return await _service.DoSomethingAsync(license).ConfigureAwait(false);
		}
		catch (Exception e)
		{
			_logger.Error(e);
			const string msg = "Unable to PUT license creation request";
			throw new ApplicationException(msg);
		}
	}
