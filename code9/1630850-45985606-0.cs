    public class PageBViewModel : BindableBase, INavigationAware
    {
        public const string Key = "PageB";
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            switch(parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    var goBackTo == parameters.GetValue<string>("goBackTo");
                    if(!string.IsNullOrWhiteSpace(goBackTo) && goBackTo != Key)
                    {
                        _navigationService.GoBackAsync(parameters);
                        return;
                    }
                    break;
            }
        }
    }
