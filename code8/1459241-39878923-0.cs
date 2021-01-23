    bool IsValidNumber(string aNumber)
    {
        bool result = false;
        aNumber = aNumber.Trim();
        if (aNumber.StartsWith("00"))
        {
            // Replace 00 at beginning with +
            aNumber = "+" + aNumber.Remove(0, 2);
        }
        try
        {
            result = PhoneNumberUtil.Instance.Parse(aNumber, "").IsValidNumber;
        }
        catch
        {
            // Exception means is no valid number
        }
        return result; 
    }
