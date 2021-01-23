    if(image2 != null) 
    {
       register.UserPicture = new byte[image2.ContentLength];
       image2.InputStream.Read(register.UserPicture, 0, image2.ContentLength);
    }
