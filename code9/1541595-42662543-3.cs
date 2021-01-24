        protected async void btConcluidoClicked(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
                await DisplayAlert("Upload", DependencyService.Get<IFtpWebRequest>().upload("ftp://ftp.swfwmd.state.fl.us", ((ListCarImagesViewModel)BindingContext).Items[0].Image, "Anonymous", "gabriel@icloud.com", "/pub/incoming"), "Ok");
            await Navigation.PopAsync();
        }
