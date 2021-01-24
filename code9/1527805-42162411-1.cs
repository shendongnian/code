    var userFromDb = db.UsersDetails.Where(u => u.identtyUserId == userDetails.identtyUserId).First();
    if (UploadImage!=null) 
    {
        byte[] buf = new byte[UploadImage.ContentLength];
        UploadImage.InputStream.Read(buf, 0, buf.Length);
        userFromDb.ImageData = buf;
    }
    userFromDb.FirstName = userDetails.FirstName;
    userFromDb.LastName = userDetails.LastName;
    userFromDb.UserAddress = userDetails.UserAddress;
    userFromDb.UserCountry = userDetails.UserCountry;
    userFromDb.UserPostalCode = userDetails.UserPostalCode;
    userFromDb.UserPhoneNumber = userDetails.PhoneNumber;
    userFromDb.CompanyId = userDetails.CompanyId;
    db.SaveChanges();
