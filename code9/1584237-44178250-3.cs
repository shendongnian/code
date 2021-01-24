    byte GetChecksum(string command)
    {
      var encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
      var data = encoding.GetBytes(command);
      byte sum = 0;
      unchecked
      {
        foreach (var b in data)
        {
            sum += b;
        }
      }
      sum |= 0x80; // if you really want to have your checksum always be >= 0x80, which isn't part of "traditional" checksum calculation
      return sum;
    }
