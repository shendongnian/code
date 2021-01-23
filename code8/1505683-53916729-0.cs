    using System.Net;
    using System.Threading.Tasks;
    using System.Threading;
    class DelayConnectRequestStream : Stream 
    {
      private HttpWebRequest _req;
      private Stream _stream = null;
      public DelayConnectRequestStream (HttpWebRequest req) 
      {
        _req = req;
      }
      public void Write (byte[] buffer, int offset, int count) 
      {
        if (_stream == null) 
        {
          _stream = req.GetRequestStream();
        }
        return _stream.Write(buffer, offset, count);
      }
      public override WriteAsync (byte[] buffer, int offset, int count, CancellationToken cancellationToken)
      {
        if (_stream == null) 
        {
          // TODO: figure out if/how to make this async 
          _stream = req.GetRequestStream();
        }
        return _stream.WriteAsync(buffer, offset, count, cancellationToken);
      }
      // repeat the pattern above for all needed methods on Stream 
      // you may need to decide by trial and error which properties and methods
      // must require an open stream. Some properties/methods you can probably just return
      // without opening the stream, e.g. CanRead which will always be false so no need to 
      // create a stream before returning from that getter. 
    } 
