    public string IsActiveString{ get; set; }
    
    [NotMapped]
    public bool IsActive
    { 
        get { return IsActiveString== "Yes"; }
        set { IsActiveString= value ? "No" : "No"; }
    }
