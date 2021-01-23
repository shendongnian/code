    public short MyFancyData {
      get {
        return bytes[2] + (bytes[3] << 8);
      }
    }
    
    public byte MyLessFancyData {
      get {
        return bytes[7];
      }
    }
    
    public bool IsCorrect {
      get {
        return bytes[0] == 0x95;
      }
    }
    // etc.
