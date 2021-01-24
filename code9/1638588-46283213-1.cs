    [DefaultValue(true)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
    public bool Enabled
    {
        get
        {
            return Model.Enabled;
        }
        set
        {
            if (value != Model.Enabled)
            {
                Model.Enabled = value;
                Model.OnPropertyChanged(() => Enabled);
            }
        }
    }
