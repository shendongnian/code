    [HostProtection(ExternalThreading = true)]
    public Task<UdpReceiveResult> ReceiveAsync()
    {
        return Task<UdpReceiveResult>.Factory.FromAsync((callback, state) => BeginReceive(callback, state), (ar)=>
            {
                IPEndPoint remoteEP = null;
                Byte[] buffer = EndReceive(ar, ref remoteEP);
                return new UdpReceiveResult(buffer, remoteEP);
 
            }, null);
    }
