    public static class Program
    {
        public static void Main(string[] args)
        {
            using (var reader = new MySerialMessageReader())
            {
                reader.MessageReaceived += (s, e) =>
                {
                    // TODO: Process message / react to it. Probably put it in a queue to be processed
                    Console.WriteLine("Received a new message: " + Encoding.UTF8.GetString(e.Message.Data));
                };
                Console.WriteLine("Waiting for data from serial port...");
                Console.ReadLine();
            }
        }
    }
    class MySerialMessageReader : IDisposable
    {
        private byte[] mBuffer = new byte[72];
        private int mReceivedCount = 0;
        private bool mIsReadingMessage;
        SerialPort mPort = new SerialPort("COM12", 9600, Parity.None);
        public event EventHandler<MessageEventArgs> MessageReaceived;
        public MySerialMessageReader()
        {
        }
        public void Start()
        {
            mPort.DataReceived += Port_DataReceived;
            mPort.Open();
        }
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Eof)
            {
                if (mIsReadingMessage && mReceivedCount < Message.MESSAGE_LENGTH)
                {
                    Debug.Fail("Received EOF before an entire message was read.");
                    return;
                }
            }
            // Put the read buffer into our cached buffer
            int n = 0;
            while (n < mPort.BytesToRead)
            {
                var readByte = (byte)mPort.ReadByte();
                if (!mIsReadingMessage && readByte == 0x55)
                {
                    mIsReadingMessage = true; // New start of message
                }
                if (mIsReadingMessage)
                {
                    // We're reading a message, put the message into a temporary buffer
                    // whilst we read(/wait for) the rest of the message
                    mBuffer[mReceivedCount++] = (byte)mPort.ReadByte();
                }
                if (mReceivedCount == Message.MESSAGE_LENGTH)
                {
                    // We've got enough to construct a message
                    Message m = null;
                    if (Message.TryParse(mBuffer, ref m))
                    {
                        if (this.MessageReaceived != null)
                            this.MessageReaceived(this, new MessageEventArgs(m));
                    }
                    else
                    {
                        Console.WriteLine("Invalid message received. Checksum error?");
                    }
                    mReceivedCount = 0;
                    Array.Clear(mBuffer, 0, 72);
                }
            }
        }
        public void Dispose()
        {
            if (mPort != null)
            {
                mPort.DataReceived -= Port_DataReceived;
                mPort.Dispose();
            }
        }
    }
    class Message
    {
        private const int CHECKSUM_LENGTH = 3;
        private const int START_INDICATOR_LENGTH = 3;
        public const int MESSAGE_LENGTH = 72;
        public byte[] Data;
        public byte[] Checksum;
        private Message(byte[] data, byte[] checkSum)
        {
            this.Data = data;
            this.Checksum = checkSum;
        }
        public static bool TryParse(byte[] data, ref Message message)
        {
            if (data.Length != MESSAGE_LENGTH)
                return false; // Unexpected message length
            if (data[0] != 0x55 || data[1] != 0x2F || data[2] != 0x48)
                return false; // Invalid message start
            var withotStartIndicator = data.Skip(START_INDICATOR_LENGTH);
            var justData = withotStartIndicator.Take(MESSAGE_LENGTH - START_INDICATOR_LENGTH - CHECKSUM_LENGTH).ToArray();
            var justChecksum = withotStartIndicator.Skip(justData.Length).ToArray();
            // TODO: Insert checksum verification of justChecksum here
            // TODO: parse justData into whatever your message look like
            message = new Message(justData, justChecksum);
            return true;
        }
    }
    class MessageEventArgs : EventArgs
    {
        public Message Message { get; set; }
        public MessageEventArgs(Message m)
        {
            this.Message = m;
        }
    }
