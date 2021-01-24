      public static void Main()
      { 
      // Define a string. 
      String original = "ASCII Encoding"; 
     // Instantiate an ASCII encoding object.
       ASCIIEncoding ascii = new ASCIIEncoding(); 
    // Create an ASCII byte array.
      Byte[] bytes = ascii.GetBytes(original); 
    // Display encoded bytes.
      Console.Write("Encoded bytes (in hex): ");
      foreach (var value in bytes)
        Console.Write("{0:X2} ", value);
        Console.WriteLine(); // Decode the bytes and display the resulting Unicode string. 
        String decoded = ascii.GetString(bytes);
        Console.WriteLine("Decoded string: '{0}'", decoded);
      }
    }
