    public class MemoryManager
    {
        private int _dataSize = 0;
        
        public enum DataTypes
        {
            Bool = 1,
            Byte = 8,
            Word = 16,
            DWord = 32
        }
        public MemoryLocation Add(DataTypes type)
        {            
            var address = GetCurrentAddress();
            _dataSize += (int)type;
            return address;
        }
        private MemoryLocation GetCurrentAddress()
        {
            int currentByteLocation = _dataSize / 8;
            int currentBitLocation = _dataSize % 8;            
            return new MemoryLocation(currentByteLocation, currentBitLocation);
        }        
    }
    public class MemoryLocation
    {
        public MemoryLocation(int byteLocation, int bitIndex)
        {
            ByteLocation = byteLocation;
            BitIndex = bitIndex;            
        }
        public int ByteLocation { get; private set; }
        public int BitIndex { get; private set; }        
        public override string ToString()
        {
            return string.Format("[{0},{1}]", ByteLocation, BitIndex);
        }
    }
