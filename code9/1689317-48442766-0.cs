        byte[] password= Convert.FromBase64String("FlU4c8yQKLkYuFwsgyU4LFeIf7m3Qwy+poMBdULEMqw=");
        byte[] salt = Encoding.ASCII.GetBytes("##oEDA102ExChAnGe99#$#");
        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password,salt,1000);
        string pdbStr =Convert.ToBase64String(pdb.GetBytes(32));
        Console.WriteLine(pdbStr);
        //outpu : RMqDMSV6d8uT2NicGM212r3KMFt7ZsOI2q8+0Rr0WZQ=
