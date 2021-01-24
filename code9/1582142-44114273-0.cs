    public class NetworkId
    {
        private static int _availibleId = 1;
        public int Id { get; } = _availibleId++;
        public static implicit operator int(NetworkId i)
        {
            return i.Id;
        }
    }
    void Test() {
        int A = new NetworkId();  //A=1
        int B = new NetworkId();  //B=2
    }
