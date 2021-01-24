    [RequiredIf("ISBN==\"\"")] // backslash is used for escaping the quotes
    public string ISBN13 { get; set; }
    
    [RequiredIf("ISBN13==\"\"")]
    public string ISBN { get; set; }
