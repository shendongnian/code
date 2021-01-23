    static void Main(string[] args)
    {
      byte[] data = { 1, 2, 3, 4, 5, 6, 7 };
      WriteByte(data, (b) => new byte[] { b }, @"C:\Temp\MyBinary1.myb");
      int[] intData = { 1, 2, 3, 4, 5, 6, 7 };
      WriteByte(intData, BitConverter.GetBytes, @"C:\Temp\MyBinary2.myb");
      long[] longData = { 1, 2, 3, 4, 5, 6, 7 };
      WriteByte(longData, BitConverter.GetBytes, @"C:\Temp\MyBinary3.myb");
      char[] charData = { '1', '2', '3', '4', '5', '6', '7' };
      WriteByte(charData, BitConverter.GetBytes, @"C:\Temp\MyBinary4.myb");
  
      string[] stringData = { "1", "2", "3", "4", "5", "6", "7" }; 
      WriteByte(stringData, Encoding.Unicode.GetBytes, "C:\Temp\MyBinary5.myb");
  
    }
