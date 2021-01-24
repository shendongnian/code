    object onedrive = localsettings.Values[_dataSyncSetting];
            if (onedrive == null)
            {
                localsettings.Values[_dataSyncSetting] = true;
                _isDataSyncEnabled = true;
                _dataPolicy = _dataSync;
            }
            else
            {
                _isDataSyncEnabled = (Boolean)onedrive;
                _dataPolicy = _isDataSyncEnabled ? _dataSync : _dataLocal;
            }
