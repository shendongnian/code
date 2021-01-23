    private async void ImportDevice()
    {
      try
      {
        await AddDeviceClickExecute();
      }
      catch (Exception ex)
      {
        ...
      }
    }
    return _importDeviceCommand
        ?? (_importDeviceCommand = new RelayCommand(ImportDevice,
          () => _selectedCableType != null
             && _selectedAddDevice != null
             && _selectedPointNames != null 
             && _selectedPointNames.Any()));
