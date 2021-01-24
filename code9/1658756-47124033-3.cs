        byte[] d;
        using (HMAC hmac = new HMACSHA256(mk))
        {
            d = hmac.ComputeHash(em);
        }
