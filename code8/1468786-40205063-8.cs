        public static void WriteBytes3<T>(T[] data, Action<T> writer)
        {
          foreach (T x in data)
          {
            writer(x);
          }
        }
    
        static void Main(string[] args)
        {
    
          using (FileStream stream = new FileStream(@"C:\Temp\MyBinary6.myb", FileMode.Create, FileAccess.Write, FileShare.None))
          using (BinaryWriter writer = new BinaryWriter(stream))
          {
            WriteBytes3(intData, writer.Write);
          }
        }
