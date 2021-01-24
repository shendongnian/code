    //IRegionManager regionManager = <get this via ctor injection, or resolve this from the contain>;
    IRegion contentRegion = regionManager.Regions["ContentRegion"];
    InterestingView view = this.container.Resolve<InterestingView>();
    // Set view.DataContext here, maybe...
    // either via the container, or newing something up
    mainRegion.Add(view);
    mainRegion.Activate(view); // shows the view
