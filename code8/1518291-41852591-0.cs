    static Tuple<double, double> GetMinMaxIntervalBasedOnBinaryNumbersThatAreRoundOnLastSevenBits(double number)
    {
      if (double.IsInfinity(number) || double.IsNaN(number))
        return Tuple.Create(number, number); // maybe treat this case differently
      var i = BitConverter.DoubleToInt64Bits(number);
      const int numberOfBitsToClear = 7; // your seven, can change this value, must be below 52
      const long precision = 1L << numberOfBitsToClear;
      const long bitMask = ~(precision - 1L);
      //truncate i
      i &= bitMask;
      return Tuple.Create(BitConverter.Int64BitsToDouble(i), BitConverter.Int64BitsToDouble(i + precision));
    }
