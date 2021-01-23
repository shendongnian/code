    byte[] source = new byte[] 
      { 97, 98, 99, 5, 15, 66, 77, 102, 0, 102, 0, 102, 0, 102, 0, 102, 0 };
    byte[] mask = new byte[] 
      { 102, 0, 102, 0, 102, 0, 102, 0 };
    // 97, 98, 99, 5, 15, 66, 77  
    Console.WriteLine(string.Join(", ", EscapeArray(0, source, mask)));
    // 97, 98, 99, 5, 15, 66, 77, 102, 0, 102, 0, 102, 0, 102, 0, 102, 0
    Console.WriteLine(string.Join(", ", EscapeArray(0, source, new byte[] {123})));
