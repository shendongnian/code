    public ActionResult CropImage(string imagePath, int? cropPointX, int? cropPointY, int? imageCropWidth, int? imageCropHeight)
        {
            string output = imagePath.Substring(imagePath.IndexOf(',') + 1);
            byte[] imageBytes = Convert.FromBase64String(output);
    
                //croppedImage will have the cropped part of the image.
            byte[] croppedImage = ImageCroping.CropImage(imageBytes, cropPointX.Value, cropPointY.Value, imageCropWidth.Value, imageCropHeight.Value);
    
            string photo = "data:image/jpeg;base64," + Convert.ToBase64String(croppedImage);
            return ContentResult(photo);
    
        }
