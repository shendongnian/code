    [HttpPost]
    [ActionName("UpdateProfilePicFromMobile")]
    public ResponseViewModel UpdateProfilePicFromMobile()
    {
        try
        {
            int userId = User.Identity.GetUserId<int>();
    
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
    
            if (userId > 0 && file?.ContentLength > 0)
            {
                var imageManager = new ImageManager();
                imageManager.SaveImage(file.InputStream, file.FileName, ImageTypes.ProfilePicture);
    
                return new ResponseViewModel() { success = true, id = pid.ToString(), message = "Image updated successfully." };
            }
    
            return new ResponseViewModel() { success = false, id = "", message = "Sorry, Image faile to update." };
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
    
            return new ResponseViewModel() { success = false, id = "", message = "Sorry, Image faile to update." + "/ " + ex.Message };
        }
    }
