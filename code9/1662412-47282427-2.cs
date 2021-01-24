    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Services.Protocols;
    
    /// <summary>
    ///   ASPX SOAP request decompression WebMethod annotation
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CompressedRequestAttribute : SoapExtensionAttribute
    {
      public override Type ExtensionType { get { return typeof(CompressedRequestExtension); } }
      public override int Priority { get { return 0; } set { } }
    }
    
    /// <summary>
    ///   ASPX SOAP request decompression implementation
    /// </summary>
    public class CompressedRequestExtension : SoapExtension
    {
      public override object GetInitializer(Type serviceType) { return null; }
    
      public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute) { return null; }
    
      public override void Initialize(object initializer) { }
    
      Stream origStream;
      StreamDelegate wrappedStream = new StreamDelegate();
    
      public override void ProcessMessage(SoapMessage message) {
        switch (message.Stage) {
          case SoapMessageStage.BeforeDeserialize:
            if (message.ContentEncoding == "gzip") {
              wrappedStream.wrapped = new GZipStream(origStream, CompressionMode.Decompress, true);
              message.ContentEncoding = null;
            }
            else if (message.ContentEncoding == "deflate") {
              wrappedStream.wrapped = new DeflateStream(origStream, CompressionMode.Decompress, true);
              message.ContentEncoding = null;
            }
            else {
              goto default;
            }
            break;
          default:
            wrappedStream.wrapped = origStream;
            break;
        }
      }
    
      public override Stream ChainStream(Stream stream) {
        origStream = stream;
        return wrappedStream;
      }
    
    }
    
    public class StreamDelegate : Stream
    {
      public Stream wrapped;
      public override bool CanRead { get { return wrapped.CanRead; } }
      public override bool CanSeek { get { return wrapped.CanSeek; } }
      public override bool CanWrite { get { return wrapped.CanWrite; } }
      public override long Length { get { return wrapped.Length; } }
      public override long Position { get { return wrapped.Position; } set { wrapped.Position = value; } }
      public override void Flush() { wrapped.Flush(); }
      public override int Read(byte[] buffer, int offset, int count) { return wrapped.Read(buffer, offset, count); }
      public override long Seek(long offset, SeekOrigin origin) { return wrapped.Seek(offset, origin); }
      public override void SetLength(long value) { wrapped.SetLength(value); }
      public override void Write(byte[] buffer, int offset, int count) { wrapped.Write(buffer, offset, count); }
    }
