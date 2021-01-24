    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApp1
    {
      class Program
      {
        static void CopyTo(Stream source, Stream destination) {
          int count;
          var array = new byte[81920];
          while ((count = source.Read(array, 0, array.Length)) != 0) {
            destination.Write(array, 0, count);
          }
        }
        static Stream LoadStream(string fullname) {
          FileStream stream = default(FileStream);
          if (fullname.EndsWith(".zip")) {
            using (stream = new FileStream(fullname, FileMode.Open)) {
              using (var compressStream = new DeflateStream(stream, CompressionMode.Decompress)) {
                var memStream = new MemoryStream();
                CopyTo(compressStream, memStream);
                memStream.Position = 0;
                return memStream;
              }
            }
          }
          return stream;
        }
        static void Main(string[] args) {
          Stream stream; Stream file;
          string RefilePath = @"^.+[^\\]+\\"; string fullname; string newFile;
          for (int i = 0; i < args.Count(); i++) {
            fullname = args[i];
            newFile = Regex.Replace(fullname, "\\.zip$", string.Empty);
            Console.Write("{0} -> {1}\r\n",
              Regex.Replace(fullname, RefilePath, string.Empty),
              Regex.Replace(newFile, RefilePath, string.Empty));
            try
            {
              stream = LoadStream(fullname);
              using (file = File.Create(newFile)) {
                CopyTo(stream, file);
              }
            }
            catch (Exception ex) {
              Console.Write("{0}", ex.ToString());
            }
          }
        }
      }
    }
