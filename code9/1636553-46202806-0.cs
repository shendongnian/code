    static string FormatNumber(string input)
    {
        var dec = decimal.Parse(input);
        var bits = decimal.GetBits(dec);
        var prec = bits[3] >> 16 & 255;
        if (prec < 2)
            prec = 2;
        return dec.ToString("N" + prec);
    }
