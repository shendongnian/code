    using System.Linq;
    ...
    string hex = "0123456789ABCDEFFEDCBA98765432100123456789ABCDEF";
    // Eliminating white spaces
    hex = string.Concat(hex.Where(c => !char.IsWhiteSpace(c))); 
    // Let "binary data based on 0x01 0x23 0xDE..." be an array
    byte[] result = Enumerable
      .Range(0, hex.Length / 2) // we have hex.Length / 2 pairs
      .Select(index => Convert.ToByte(hex.Substring(index * 2, 2), 16))
      .ToArray();
    // Test (let's print out the result array with items in the hex format)
    Console.WriteLine(string.Join(" ", result.Select(b => $"0x{b:X2}")));
