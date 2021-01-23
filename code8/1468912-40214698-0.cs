    oldCode = sdr["TCODE"].ToString();
    if (string.IsNullOrEmpty(oldCode))
    {
        newCode = codevalue + "0001A";
    }
    else
    {
        int newIncrement = Convert.ToInt32(oldCode.Substring(1, 4)) + 1;
        newCode = codevalue + newIncrement.ToString().PadLeft(4, '0') + oldCode.Substring(5, 1);
    }
