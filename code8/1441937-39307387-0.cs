    var regionManager = container.Resolve<IRegionManager>();
    if (screenName == SpEnums.ViewName.LuminationView.ToString())
    {
         regionManager.RequestNavigate(Enums.Regions.MainRegion.ToString(),
         SpEnums.ViewName.LuminationView.ToString());
    }
    else if()...
