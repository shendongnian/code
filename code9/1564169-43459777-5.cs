    public System.DateTime ValidFrom { get; set; }
    public Nullable<System.DateTime> ValidTo { get; set; }
    
    // These will be formatted versions of the properties specifically for output
    public string FormattedFrom => ValidFrom.ToString("dd/MM/yyyy");
    public string FormattedTo => ValidTo?.ToString("dd/MM/yyyy") ?? "Present";
