    protected override void ConfigureContainer()
    {
    		base.ConfigureContainer();    
    		this.Container.ComposeExportedValue<Model1>(new Model1());
    }
