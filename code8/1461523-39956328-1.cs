        class Program
        {
            static void Main(string[] args)
            {
                LedVals ledVals = new LedVals();
                int size = Marshal.SizeOf(ledVals); ;
                IntPtr ptr = Marshal.AllocHGlobal(size);
                byte[] buffer = new byte[Marshal.SizeOf(ledVals)];
                Marshal.StructureToPtr(ledVals, ptr, true);
                Marshal.Copy(ptr, buffer, 0, Marshal.SizeOf(ledVals));
                Marshal.FreeHGlobal(ptr);
                FileStream stream = File.OpenWrite("FILENAME");
                BinaryWriter bWriter = new BinaryWriter(stream, Encoding.UTF8);
                bWriter.Write(buffer);
     
            }
        }
       [StructLayout(LayoutKind.Sequential)]
        public class LedVals
        {
           public int ID { get; set; }
        }
