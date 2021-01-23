csharp
[SerializeField] private Text m_Text;
async UniTaskVoid Connect() {
    IPEndPoint endPoint = new IPEndPoint(IPAddress.IPv6Loopback, 12345);
    // Create a socket client by connecting to the server at the IPEndPoint.
    // See the UniRx Async tooling to use await 
    IRxSocketClient client = await endPoint.ConnectRxSocketClientAsync();
    client.ReceiveObservable
        .ToStrings()
        .ObserveOnMainThread()
        .Subscribe(onNext: message =>
    {
        m_Text.text = message;
    }).AddTo(this);
    // Send a message to the server.
    client.Send("Hello!".ToByteArray());
}
