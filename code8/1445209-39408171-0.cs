    string sequenceStr = "";
    for (int i = 1; i < 100; i++)
        sequenceStr += i.ToString();
    for (int i = 0; i < 26; i++)
    {
        for (int j = 0; j < 36; j++)
        {
            sequenceStr += Encoding.UTF8.GetString(new byte[] { (byte)(i + 65) }); // A=65, B=66, ...
            if (j < 10)
            {
                sequenceStr += j.ToString();
            }
            if (j > 9)
            {
                sequenceStr += Encoding.UTF8.GetString(new byte[] { (byte)(j + 55) }); 
            }
        }
    }
