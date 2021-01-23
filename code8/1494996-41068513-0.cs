    private void DisplayImageFromDb(Guid id)
    {
        using (var context = new DataContext())
        {
            var item = context
                .tblShips
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
    
            if (item == null)
                throw new Exception("Image could not be found!");
    
            //Convert the byte[] to a BitmapImage
            BitmapImage img = new BitmapImage();
            MemoryStream ms = new MemoryStream(item.Picture);
            img.BeginInit();
            img.StreamSource = ms;
            img.EndInit();
    
            //assign the image to the Source property of the Image Control.
            imgControl.Source = img;
        }
    }
