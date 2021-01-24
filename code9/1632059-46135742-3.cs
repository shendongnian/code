    public class NavigationMenuButtonTemplateViewModel : Mvvm.ViewModelBase
    {
        ButtonInfo _ButtonInfo = default(ButtonInfo);
        public NavigationMenuButtonTemplateViewModel() { }
        public NavigationMenuButtonTemplateViewModel(ButtonInfo buttonInfo)
        {
            ButtonInfo = new ButtonInfo
            {
                BenefitKind = buttonInfo.BenefitKind,
                Status = buttonInfo.Status,
                MenuName = buttonInfo.MenuName,
                Symbol = buttonInfo.Symbol
            };
        }
        public ButtonInfo ButtonInfo
        {
            get { return _ButtonInfo; }
            set { Set(ref _ButtonInfo, value); }
        }
        public DelegateCommand NavigateToPageCommand => new DelegateCommand(async () => { await ExecuteNavigateToPageCommand(); });
        private async Task ExecuteNavigateToPageCommand()
        {
            var message = new MessageDialog("Test");
            await message.ShowAsync();
        }
    }
