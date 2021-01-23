     if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.CurrentApp.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            _mediaFile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });
            if (_mediaFile == null)
                return;
            //ViewModel.StoreImageUrl(file.Path);
            await App.CurrentApp.MainPage.DisplayAlert("Snap", "Your photo have been added to your Items collection.", "OK");
            ImageSource = ImageSource.FromStream(() =>
            {
                var stream = _mediaFile.GetStream();
                _mediaFile.Dispose();
                return stream;
            });
