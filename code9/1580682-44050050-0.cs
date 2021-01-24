    public abstract class Packet
    {
        public int PacketType { get; }
        public Packet (int packetType)
        {
            PacketType = packetType;
        }
        protected abstract byte[] GetPayload ();
        private int CalculateChecksum ()
        {
            byte[] packetTypeBytes = BitConverter.GetBytes (PacketType);
            byte[] payloadBytes    = GetPayload ();
            byte[] lengthBytes     = BitConverter.GetBytes (payloadBytes.Length);
            return 0; // add some logic to calculate checksum from all bytes
        }
        public byte[] ToBytes ()
        {
            byte[] packetTypeBytes = BitConverter.GetBytes (PacketType);
            byte[] checksumBytes   = BitConverter.GetBytes (CalculateChecksum ());
            byte[] payloadBytes    = GetPayload ();
            byte[] lengthBytes     = BitConverter.GetBytes (payloadBytes.Length);
            return packetTypeBytes.Concat (lengthBytes).Concat (checksumBytes).Concat (payloadBytes).ToArray ();
        }
    }
    public sealed class ActionA : Packet
    {
        public string Message { get; }
        public ActionA (string message) : base (0)
        {
            Message = message;
        }
        protected override byte[] GetPayload ()
        {
            return Encoding.ASCII.GetBytes (Message);
        }
        
    }
    public sealed class ActionB : Packet
    {
        public int Value { get; }
        public ActionB (int value) : base (1)
        {
            Value = value;
        }
        protected override byte[] GetPayload ()
        {
            return BitConverter.GetBytes (Value);
        }
    }
