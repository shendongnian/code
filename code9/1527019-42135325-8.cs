      using System.Linq;
      ...
      Byte[] receiveBytes = new byte[] {
        20, 20, 20, 20, 20, 20, 20, 20, 20, 49,  // 9 spaces then '1'
        20, 20, 20, 20, 20, 20, 20, 20, 20, 50,  // 9 spaces then '2'
        20, 20, 20, 20, 20, 20, 49, 50, 51, 52,  // 6 spaces then '1' '2' '3' '4'
        20, 20, 20, 20, 20, 20, 53, 56, 48, 49,  // 6 spaces then '5' '8' '0' '1'
        20, 20, 20, 20, 20, 20, 20, 57, 57, 57}; // 7 spaces then '9' '9' '9'
      int[] intvalues = Enumerable.Range(0, receiveBytes.Length / 10)
        .Select(index => receiveBytes
           .Skip(index * 10) // Skip + Take: splitting on 10-items chunks
           .Take(10)                  
           .Where(b => b >= '0' && b <= '9') // just digits 
           .Aggregate(0, (s, a) => s * 10 + a - '0')) 
        .ToArray();
