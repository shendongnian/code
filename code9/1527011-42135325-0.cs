      using System.Linq;
      ...
      Byte[] receiveBytes = new byte[] {
        20, 20, 20, 20, 20, 20, 20, 20, 20, 49,
        20, 20, 20, 20, 20, 20, 20, 20, 20, 50,
        20, 20, 20, 20, 20, 20, 49, 50, 51, 52,  
        20, 20, 20, 20, 20, 20, 53, 56, 48, 49,  
        20, 20, 20, 20, 20, 20, 20, 57, 57, 57};
      int[] intvalues = Enumerable.Range(0, receiveBytes.Length / 10)
        .Select(index => receiveBytes
           .Skip(index * 10) // Skip + Take: splitting on 10-items chunks
           .Take(10)                  
           .Where(b => b >= '0' && b <= '9') // just digits 
           .Aggregate(0, (s, a) => s * 10 + a - '0')) 
        .ToArray();
