    using System;
    using System.IO;
    using SharpCompress.Compressors;
    using SharpCompress.Compressors.Deflate;
    
    public class ThisWouldBeTheDatabaseClient {
      public void f(Stream s) {
        // some implementation I don't have access to
        // The only thing I know is that it reads data from the stream in some way.
        var buffer = new byte[10];
        s.Read(buffer,0,10);
      }
    }
    
    public class Program {
      public static void Main() {
        var dummyDatabaseClient = new ThisWouldBeTheDatabaseClient();
        var dataBuffer = new byte[1000];
        var fileStream= new MemoryStream( dataBuffer ); // would be "File.OpenRead(path)" in real case
        using(var dstream = new DeflateStream(
            fileStream, CompressionMode.Compress, CompressionLevel.BestCompression))
            dummyDatabaseClient.f(dstream);
      }
    }
