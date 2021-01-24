    sealed partial class App : Application
    {
        ...
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            await ConfigureJumpList();
            ...
            if(e.Arguments == "GoToSecondPage")
            {
                rootFrame.Navigate(typeof(SecondPage));
            }
            else if(e.Arguments == "GoToThirdPage")
            {
                rootFrame.Navigate(typeof(ThirdPage));
            }
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
