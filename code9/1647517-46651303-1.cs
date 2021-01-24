    private string _elementXml;
    [DefaultValue("")]
    public string ElementXml
    {
        get => _elementXml;
        set => _elementXml = string.IsNullOrWhiteSpace(value) ? null : value;
    }
