    using System.IO;
    
    class ConsoleApplication {
        static void Main()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("temp.dat", FileMode.Create)))
            {
                writer.Write(1.2345F);
            }
        } }
