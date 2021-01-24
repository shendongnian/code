    using System;
    using System.IO;
    using System.Text;
    namespace ConsoleApp1
    {
       class Program
       {
          public const int PeHeaderOffset = 0x003C;
          public const int CheckSumOffset = 0x0058;
          static void Main(string[] args)
          {
             while (true)
             {
                Console.Write("Path to PE file: ");
                string path = Console.ReadLine();
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                   byte[] peHeaderPointer = new byte[4];
                   byte[] checkSum = new byte[4];
                   peHeaderPointer = ReadPeHeaderPointer(fileStream);
                   int checkSumOffSet = BitConverter.ToInt32(peHeaderPointer, 0);
                   checkSum = ReadChecksum(fileStream, checkSumOffSet);
                   string hex = ByteArrayToHexString(checkSum);
                   Console.WriteLine($"Checksum: {hex}");
                   Console.ReadLine();
                }
             }
          }
          //This will not reverse the bytes because the BitConvert.ToInt32 is already reading it in the correct order.
          public static byte[] ReadPeHeaderPointer(FileStream fileStream)
          {
             byte[] bytes = new byte[4];
             fileStream.Seek(PeHeaderOffset, SeekOrigin.Begin);
             fileStream.Read(bytes, 0, 4);
             return bytes;
          }
          //This reverses the bytes to that this tool will match dumpbin /headers and dotPeek
          public static byte[] ReadChecksum(FileStream fileStream, int offSet)
          {
             byte[] bytes = new byte[4];
             fileStream.Seek(offSet + CheckSumOffset, SeekOrigin.Begin);
             fileStream.Read(bytes, 0, 4);
             bytes = ReverseBytes(bytes);
             return bytes;
          }
          //The PE file seems to be written to the file system in Big Endian 
          //I need to read them in Small Endian to match dumpbin and dotPeek
          public static byte[] ReverseBytes(byte[] bytes)
          {
             byte[] tempBytes = new byte[4];
             tempBytes[0] = bytes[3];
             tempBytes[1] = bytes[2];
             tempBytes[2] = bytes[1];
             tempBytes[3] = bytes[0];
             return tempBytes;
          }
          public static string ByteArrayToHexString(byte[] ba)
          {
             StringBuilder hex = new StringBuilder(ba.Length * 2);
             foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
             return hex.ToString().ToUpper();
          }
       }
    }
