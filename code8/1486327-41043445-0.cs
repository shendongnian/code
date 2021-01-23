    [Bindable]
    sealed partial class App : BootStrapper
    {
        static ViewModels.DetailPageViewModel _reusedDetailPageViewModel;
        public override INavigable ResolveForPage(Page page, NavigationService navigationService)
        {
            if (page.GetType() == typeof(Views.DetailPage))
            {
                if (_reusedDetailPageViewModel == null)
                {
                    _reusedDetailPageViewModel = new ViewModels.DetailPageViewModel();
                }
                return _reusedDetailPageViewModel;
            }
            else
            {
                return null;
            }
        }
    }
