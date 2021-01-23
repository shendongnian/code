    namespace projectName
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fs = new FileStream(@"c:\folder\mfc-archive.dat", FileMode.Open);
                var len = (int)fs.Length;
                var bits = new byte[len];
                fs.Read(bits, 0, len);
                Console.WriteLine(BitConverter.ToString(bits));
            }
        }
    }
