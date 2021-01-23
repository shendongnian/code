    private static int bin(string binaryNumber) {
      Regex rgx = new Regex(@"^[01]+$");
      if (!rgx.IsMatch(binaryNumber)) {
        Console.WriteLine("Binary number should include only 0 and 1");
      }
      // rest removed for brevity
    }
