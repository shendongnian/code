    private void lstPhotoType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = lstPhotoType.SelectedItems.Count();
            if (count > 0)
            {
                foreach (PictureTypes listBoxItem in lstPhotoType.SelectedItems.OfType<PictureTypes>())
                {
                    string value = listBoxItem.pType; //<- value = ".BMP" or ".JPG", etc.
                }
            }
        }
