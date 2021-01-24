    byte[] passBytes = new byte[]
        {164,176,124,62,244,154,226,211,177,90,202,180,12,142,25,225};
    byte[] saltBytes = new byte[]
        {173,205,190,172,239,190,242,63,219,205,173,196,218,171,142,214};
    var pbkdf2 = new Rfc2898DeriveBytes(passBytes, saltBytes, 1000);
    var key = Convert.ToBase64String(pbkdf2.GetBytes(16));
