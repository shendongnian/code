    // a private field on the class level
    private string _currentImageFilePath;
    private async void btcapture_Click(object sender, RoutedEventArgs e)
    {
        var cameraUI = new CameraCaptureUI();
        cameraUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
        cameraUI.PhotoSettings.CroppedSizeInPixels = new Size(150, 150);
        var photo = await cameraUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
                
        if (photo == null) return;
    
        // Create a unique filename
        var uniqueFileName = $"{Guid.NewGuid()}.jpg";
        // Save the photo file in the app's Local folder
        var savedFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(uniqueFileName, CreationCollisionOption.GenerateUniqueName);
    
        // -- Now you have an easy to store string using the file's Path property -- //
                
        // 1 - Use this string to save to the database
        _currentImageFilePath = savedFile.Path;
    
        // 2 - You can also use the same file path to set the <Image/> source
        // you do NOT need to decode the image manually
        Capture.Source = new BitmapImage(new Uri(savedFile.Path));
    }
    
    private async Task SaveToDatabase()
    {
        var selectedDate = Data1.Date.UtcDateTime;
                
        var Db_Pet = new DataBaseHelper();
    
        if (txtnombre.Text != "" & txtchip.Text != "" & txtraza.Text != "" & Selectedgenero.Text != "" & txtcolor.Text != "")
        {
            var petToInsert = new Mascota
            {
                Name = txtnombre.Text,
                Chip = txtchip.Text,
                ImageFilePath = _currentImageFilePath
            };
    
            Db_Pet.Insert(petToInsert);
        }
        else
        {
            await new MessageDialog("Enter your pet").ShowAsync();
        }
    }
