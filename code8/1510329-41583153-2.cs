    private void UpdatePrimaryImage(PropertyImage oldImage, PropertyImage newImage)
    {
        // Pass in the original primary PropertyImage and the new one obtained from the UI.
    
        // Check that we do not have the same image, otherwise no change needs to be made:
        if(oldImage.IsPrimary != newImage.IsPrimary)
        {
            oldImage.IsPrimary = false;
            newImage.IsPrimary = true;
            Update(oldImage);
            Update(newImage);
            SaveChanges;
        }
    }
