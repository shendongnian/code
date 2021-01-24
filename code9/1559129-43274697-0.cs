    public abstract class Packet<TResponse> {
        // other members here
        public abstract TResponse DecodeResponse(byte[] raw);
    }
    public class IntPacket : Packet<int> {
        public override int DecodeResponse(byte[] raw) {
            // decode
            return 0;
        }
    }
