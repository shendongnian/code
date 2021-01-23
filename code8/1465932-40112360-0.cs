    try
    {
      await Task.Run(() =>
      {
        if (_proxy != null)
        {
          _gpsdService.SetProxy(_proxy.Address, _proxy.Port);
          if (_proxy.IsProxyAuthManual)
          {
            _gpsdService.SetProxyAuthentication(_proxy.Username,
                StringEncryption.DecryptString(_proxy.EncryptedPassword, _encryptionKey).ToString());
          }
        }
        _gpsdService.OnLocationChanged += GpsdServiceOnOnLocationChanged;
        _gpsdService.StartService();
      });
    }
    catch (Exception ex)
    {
      // You're back on the UI thread here
      ... // handle exception
    }
