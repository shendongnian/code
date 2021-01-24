      using System.Collections;
      using System.Linq; 
      ...
      uint source = 62000;
      BitArray array = new BitArray(BitConverter.GetBytes(source));
      string result = string
        .Concat(array
           .OfType<bool>()
           .Reverse()
           .Select(item => item ? 1 : 0))
        .TrimStart('0');
      Console.WriteLine(result);
