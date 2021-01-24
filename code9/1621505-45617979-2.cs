    int i = 0;
    for (i = 0; i < bytes.Length; i++)
    {
        intAscSum = intAscSum + bytes[i];
    }
    byte[] bytes = Encoding.UTF8.GetBytes(strMsg); 
