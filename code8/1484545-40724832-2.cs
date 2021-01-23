    try
    {
        i_Crypt.Write(u8_Data, 0, u8_Data.Length);
        if (b_Encrypt)
            return Convert.ToBase64String(i_Mem.ToArray());
        else
            return Encoding.Unicode.GetString(i_Mem.ToArray());
    }
    catch
    {
        return null;
    }
    finally
    {
        i_Crypt.Close();
    }
