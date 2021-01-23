    public Image getphoto(int id)
    {
        using (var db = new simisdbEntities())
        {
            var imgMetadata = db
                    .FarmerImages
                    .FirstOrDefault(p => p.id == id);
        
            //handle the case when image does not exist.
            if (imgMetadata == null)
                throw new Exception("Image not found!");
        
            //read the image bytes into an Image object.
            var img = Image.FromStream(new MemoryStream(imgMetadata.photo.ToArray()));
            
            return img;
        }
    }
