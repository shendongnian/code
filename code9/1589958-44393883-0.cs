        private async void TakePicture()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "Aceptar");
            }
            file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg",
                PhotoSize = PhotoSize.Small,
            });
            //IsRunning = true;
            if (file != null)
            {
                ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
			else
			{
			    // Recursion - I believe that this would continue until the file is not null, then it would carry on.
				TakePicture();
			}
			
            IsRunning = false;
        }
