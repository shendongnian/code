    //This class will store ongoing requests and also will be used as the async parameter
    public class ExecutingRequest
    {
        public Guid Id { get; set; }
        public NetworkStream Stream { get; set; }
    }
    //Somewhere in your server class
    ConcurrentDictionary<Guid, ExecutingRequest> pendingRequests = new ConcurrentDictionary<Guid, ExecutingRequest>();
    
    private void Send(string msg)
    {
        NetworkStream stream;
        byte[ ] packetBuffer = Encoding.ASCII.GetBytes(msg);
        stream = clientDevice.GetStream();
        var request = new ExecutingRequest{ Stream = stream, Id = Guid.NewGuid() };
        pendingRequests.AddOrUpdate(request.Id, request, (a,b) => request);
        stream.BeginWrite(packetBuffer, 0, packetBuffer.Length, new AsyncCallback(StreamWriteCompleteCallback), request);
    }
    private void StreamWriteCompleteCallback(IAsyncResult ar) 
    {
        try {
            ExecutingRequest req = (ExecutingRequest)ar.AsyncState;
            pendingRequests.TryRemove(req.Id, out ExecutingRequest dummy);
            req.stream.EndWrite(ar);
        }
        catch (ObjectDisposedException) 
        {
            // client device was disconnected by the server before write completed
        }
    }
