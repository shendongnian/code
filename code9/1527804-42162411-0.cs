    if (UploadImage!=null) 
    {
        byte[] buf = new byte[UploadImage.ContentLength];
        UploadImage.InputStream.Read(buf, 0, buf.Length);
        userDetails.ImageData = buf;
        db.Entry(userDetails).State = EntityState.Modified;//error here
        db.SaveChanges();
    }
