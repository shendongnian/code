      private static void SetValue(string input) {
        byte[] res = 
          (BitConverter.IsLittleEndian 
             ? BitConverter.GetBytes(int.Parse(input)).Reverse() 
             : BitConverter.GetBytes(int.Parse(input)))
          .SkipWhile(b => b == 0)
          .DefaultIfEmpty() // we don't want trim all in case of input == 0
          .ToArray();
        // Console.WriteLine(string.Concat(res.Select(b => b.ToString("X2")))); 
        //TODO: relevant code here
      }
