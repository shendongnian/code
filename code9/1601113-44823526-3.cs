    private string _weaponName;
    public string WeaponName
    {
        get { return this._weaponName; }
        set { SetAndRaiseIfChanged(ref this._weaponName, value); }
    }
