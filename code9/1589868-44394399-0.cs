    [ViewModelToModel(nameof(LoadOpts))]
    public string FolderPath {get; set;}
    
    [Model]
    [Expose("PropertyA")]
    [Expose("PropertyB")]
    public LoadOptions LoadOpts {get; set; }
