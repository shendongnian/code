    using System.IO;
    using System;
    
    public class UnsafeAndBinaryWriter
    {
        public unsafe static void Main(String[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Hex buffer(unsafe): {0}", BitConverter.ToString(SerializeUnsafe(arr)));
            Console.WriteLine("Hex buffer        : {0}", BitConverter.ToString(Serialize(arr)));
        }
        private static unsafe byte[] SerializeUnsafe(int[] arr)
        {
            int totalSize = arr.Length * sizeof(int);
            byte[] resultBuffer = new byte[totalSize];
            // Of course you can do it without unsafe magic :)
            fixed (int* p = (&arr[0])) {
                byte* ptr = (byte*)p;
                for (int i = 0; i < totalSize; i++, ptr++)
                    resultBuffer[i] = *ptr;
            }
            return resultBuffer;
        }
        private static byte[] Serialize(int[] arr)
        {
            byte[] resultBuffer = null;
            // Stream for storing result
            using (var stream = new MemoryStream()) {
                using (BinaryWriter bw = new BinaryWriter(stream)) {
                    for (int i = 0; i < arr.Length; i++)
                        bw.Write(arr[i]);
                }
                resultBuffer = stream.ToArray();
            }
            return resultBuffer;
        }
    }
