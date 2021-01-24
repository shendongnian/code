    protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
    {
        RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
        mappings.RegisterMapping(typeof(HamburgerMenuItemCollection), Container.Resolve<HamburgerMenuItemCollectionRegionAdapter>());
        return mappings;
    }
