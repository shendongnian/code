    public ObservableCollection<BitmapImage> listOfCapturedImages { get; } = 
       new ObservableCollection<BitmapImage>();
    
    private void addNewImageButton_Click(object sender, RoutedEventArgs e)
            {
                CameraWindow cw = new CameraWindow(this);
                cw.newlyCapturedImage += (BitmapImage newImage) =>
                {
                    listOfCapturedImages.Add(newImage);
                    newlyAddedImage.Source = newImage;
                };
                cw.Show();
            }
