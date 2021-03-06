    private static char ArabicChr(int chrCode) {
      if (chrCode < byte.MinValue || chrCode > byte.MaxValue)
        throw new ArgumentOutOfRangeException(
          "chrCode",
         $"chrCode must be in [{byte.MinValue}..{byte.MaxValue}] range");
      return Encoding.GetEncoding(1256).GetString(new byte[] { (byte)chrCode })[0];
    }
