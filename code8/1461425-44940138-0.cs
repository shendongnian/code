    /// <summary>
    /// Helper method to handle the special symbol text.
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    private char HexToChar(string hex)
    {
        return (char)ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);
    }
