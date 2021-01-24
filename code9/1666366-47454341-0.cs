      using System.Linq;
      ...
      DateTime date1 = new DateTime(2016, 12, 16, 16, 44, 39);
      string result = string.Concat(BitConverter.IsLittleEndian
        ? BitConverter.GetBytes(date1.Ticks).Reverse().Select(b => b.ToString("X2"))
        : BitConverter.GetBytes(date1.Ticks).Select(b => b.ToString("X2"))
      );
      Console.WriteLine(result);
