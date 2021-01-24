    0~9 [48 - 57]
    a~z [97 - 122]
    .-  [45 - 46]
        string s = "9quali52ty3";
        byte[] ASCIIValues = System.Text.Encoding.ASCII.GetBytes(s);
        bool IsValidAlphaNumeric = true;
        foreach (byte b in ASCIIValues)
        {
            if (b < 45 || (b == 47 || (b > 57 && b < 96) || b > 122)){
                IsValidAlphaNumeric = false;
                break;
            }
        }
        Console.WriteLine(IsValidAlphaNumeric);
