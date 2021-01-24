    [global::System.Configuration.UserScopedSettingAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Configuration.SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Binary)]
    [global::System.Configuration.DefaultSettingValueAttribute(null)]
    public ObservableCollection<Clock> SavedClocks
    {
        get
        {
            return ((ObservableCollection<Clock>)(this["SavedClocks"]));
        }
        set
        {
            this["SavedClocks"] = value;
        }
    }
