    public class Message
    {
        public Message()
        {
            Payload = new Payload();
            RawData = new List<byte>();
        }
        public byte Address { get; set; }
        public byte Length { get; set; }
        public Payload Payload { get; set; }
        public byte Checksum { get; set; }
        public List<byte> RawData { get; set; }
    }
    enum RxState
    {
        AwaitStartCharacter,
        AwaitLengthCharacters,
        AwaitPayloadCharacters,
        AwaitChecksumCharacters
    }
    private void RxBufferQueueConsumer()
    {
        var rxState = RxState.AwaitStartCharacter;
        Message rxMessage = null;
        while (!_cts.IsCancellationRequested)
        {
            CheckRxBufferQueue(ref rxState, ref rxMessage);
        }
    }
    private BlockingCollection<byte> _rxBufferQueue;
    private CancellationTokenSource _cts;
    private void CheckRxBufferQueue(ref RxState rxState, ref Message rxMessage)
    {
        byte rxByte;
        if (_rxBufferQueue.TryTake(out rxByte, 50))
        {
            switch (rxState)
            {
                case RxState.AwaitStartCharacter:
                    AwaitStartCharacter(ref rxState, rxByte, ref rxMessage);
                    break;
                case RxState.AwaitLengthCharacters:
                    AwaitLengthCharacters(ref rxState, rxByte, ref rxMessage);
                    break;
                case RxState.AwaitPayloadCharacters:
                    AwaitPayloadCharacters(ref rxState, rxByte, ref rxMessage);
                    break;
                case RxState.AwaitChecksumCharacters:
                    AwaitChecksumCharacters(ref rxState, rxByte, ref rxMessage);
                    break;
            }
        }
    }
