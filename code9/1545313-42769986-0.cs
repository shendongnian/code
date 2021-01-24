          public override void OnAppearing() {
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "MyPhoto",
                Name = "Nextflow.jpg",
                SaveToAlbum = true
            });
            if (file == null)
                return;
            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
          }
