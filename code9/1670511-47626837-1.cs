    public static IObservable<RemoteData> UdpStream(IPEndPoint endpoint)
        {
            return Observable.Using(() => new UdpClient(endpoint),
                udpClient => Observable.Defer(() =>
                    udpClient.ReceiveAsync().ToObservable()).Repeat().Select(b => new RemoteData(Encoding.UTF8.GetString(b.Buffer))));
        }
