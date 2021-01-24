    public bool BiometricViewVisible
    {
        get
        {
            return _biometricViewVisible;
        }
        set
        {
            _biometricViewVisible = value;
            OnPropertyChanged(nameof(BiometricViewVisible));
            if (value)
            {
                OnLoadedCommand.Execute(null);
            }
        }
    }
