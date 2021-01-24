    byte[] bytes = BitConverter.GetBytes(input);
            
    if (BitConverter.IsLittleEndian)
           Array.Reverse(bytes);
     Console.WriteLine("byte array: " + 
          BitConverter.ToString(bytes).Replace("-", string.Empty));
