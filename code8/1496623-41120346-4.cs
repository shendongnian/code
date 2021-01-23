    byte[] buffer = Encoding.UTF8.GetByes(passText.Text);
    SqlParameter paramPassword = null;
    using ( SHA512 sha= new SHA512Managed())
    {
        byte[] hash = sha.ComputeHash(buffer);
        StringBuilder builder= new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            builder.Append(hash[i].ToString("x2"));
        }
        paramPassword  = new SqlParameter("@userPass", builder.ToString());
    }
