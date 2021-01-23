        private async void Button_OnClick(object sender, RoutedEventArgs e)   
        {
            Uri url=new Uri(@"Skype:number?call");
            var areSkypeCall = await Windows.System.Launcher.LaunchUriAsync(url);
            if (areSkypeCall)
            {
                //Success
            }
        }
