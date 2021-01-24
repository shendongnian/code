    private void Webcam_PhotoTakenEvent(Bitmap inImage)
    {
         // Set the Date Taken in the EXIF Metadata
         var newItem = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));
         newItem.Id = 36867; // Taken date
         newItem.Type = 2;
         // The format is important the decode the date correctly in the futur
         newItem.Value =  System.Text.Encoding.UTF8.GetBytes(DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss") + "\0");
         newItem.Len = newItem.Value.Length;
         inImage.SetPropertyItem(newItem);
         // Save the photo on disk
         inImage.Save(_currentPath + "/BV_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpeg");
    }
