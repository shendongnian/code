    public class Program
    {
        public static void Main(string[] args)
        {
            var startPacket = new StartPacket();
            startPacket.len = 3;
            startPacket.points = new List<double>() { 3.14, 5, -1023.1231311 };
            // serialize into a byte array for Socket.SendTo()
            var formatter = new BinaryFormatter();
            var ms = new MemoryStream();
            formatter.Serialize(ms, startPacket);
            var bytes = ms.ToArray();
            // assuming we received bytes[] from a socket, deserialize into StartPacket object
            ms = new MemoryStream(bytes);
            formatter = new BinaryFormatter();
            startPacket = (StartPacket)formatter.Deserialize(ms);
        }
    }
    [Serializable()]
    public struct StartPacket
    {
        public uint len;
        public List<double> points;
    }
