    public async Task<StartServiceResult> StartService(string password = null)
    {
        if (!string.IsNullOrEmpty(password))
        {
            _serviceController.Start(new[] {password});
            await _serviceController.WaitForStatusAsync(ServiceControllerStatus.Running);
            return new StartServiceResult { Success = true, Message = "Started from password" };
        }
        else if (TokenAccessFileExists())
        {
            _serviceController.Start();
            await _serviceController.WaitForStatusAsync(ServiceControllerStatus.Running);
            return new StartServiceResult { Success = true, Message = "Started from token" };
        }
        return new StartServiceResult { Success = false, Message = "Failed to start: no password nor token." };
    }
