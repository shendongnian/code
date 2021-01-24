    private static byte[] GetPropValueValue(byte[] propValue)
    {
      // Since the encoding algorithm doubles the space used, we halve it.
      var propValueValue = new byte[propValue.Length / 2];
    
      // Parse the encoded bytes two-by-two, since the encoding algorithm transforms
      // one bytes in two bytes we need to read two of them to obtain the original one.
      for (var j = 0; j < propValue.Length; j = j + 2)
      {
        // Compute the two halves (nibbles) of the original byte from the values of the
        // two encoded bytes. Each encoded bytes is actually an hexadecimal character,
        // so each encoded byte can only have a value between 48 and 57 ('0' to '9')
        // or between 97 and 102 ('a' to 'f'). Yes, it's an utter waste of space.
        var highNibble = HexToInt(propValue[j]);
        var lowNibble = HexToInt(propValue[j + 1]);
    
        // Recreate the original byte from the two nibbles.
        propValueValue[j / 2] = (byte) (highNibble << 4 | lowNibble);
      }
    
      return propValueValue;
    }
