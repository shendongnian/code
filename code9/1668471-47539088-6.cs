    sealed partial class App : Template10.Common.BootStrapper
    {
        ...
        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            if ((args as LaunchActivatedEventArgs).Arguments == "GoToSecondPage")
                await NavigationService.NavigateAsync(typeof(Views.SecondPage));
            else if ((args as LaunchActivatedEventArgs).Arguments == "GoToThirdPage")
                await NavigationService.NavigateAsync(typeof(Views.ThirdPage));
            else
                await NavigationService.NavigateAsync(typeof(Views.MainPage));
            await ConfigureJumpList();
        }
        ...
        private async Task ConfigureJumpList()
        {
            JumpList jumpList = await JumpList.LoadCurrentAsync();
            jumpList.Items.Clear();
            jumpList.Items.Add(JumpListItem.CreateWithArguments("GoToSecondPage", "Go directly to the 2nd page"));
            jumpList.Items.Add(JumpListItem.CreateWithArguments("GoToThirdPage", "Visit 3rd page"));
            await jumpList.SaveAsync();
        }
    }
