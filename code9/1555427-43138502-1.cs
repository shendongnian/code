    public class Message
    {
        const string REQUEST_SCHEME = "{0} {1} HTTP/1.1\r\nHost: {hostname}\r\nContent-Length: 0\r\n\r\n";
        string request;
        Action<MessageResult> whenCompleted;
    
        public Message(string requestUri, string requestType, Action<MessageResult> whenCompleted)
        {
            request = string.Format(REQUEST_SCHEME, requestType, requestUri);
            this.whenCompleted = whenCompleted;
        }
    
        public MessageResult Process(Socket s)
        {
            IPEndPoint endPoint = (IPEndPoint)s.RemoteEndPoint;
            IPAddress ipAddress = endPoint.Address;
            request = request.Replace("{hostname}", ipAddress.ToString());
            s.Send(Encoding.UTF8.GetBytes(request));
            
            // receive header here which should look somewhat like this :
            /*
                    HTTP/1.1 <status>
                    Date: <date>
                    <some additional info>
                    Accept-Ranges: bytes
                    Content-Length: <CONTENT_LENGTH>
                    <some additional info>
                    Content-Type: <content mime type>
             */
             // when you receive this all that matters is <CONTENT_LENGTH>
             int contentLength = <CONTENT_LENGTH>;
             byte[] msgBuffer = new byte[contentLength];
             if (s.Receive(msgBuffer) != contentLength )
             {
                 return null;
             }
    
             return new MessageResult(msgBuffer, whenCompleted);
        }
    }
