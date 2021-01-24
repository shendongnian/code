    public class MemoryManager
    {
        private MemoryLocation _addressIndex = new MemoryLocation(0,0);
        
        public enum DataTypes
        {
            Bool = 1,
            Byte = 8,
            Word = 16,
            DWord = 32
        }
        public MemoryLocation Add(DataTypes type)
        {
            var dataAddressIndex = _addressIndex;
            SetNextAddress(type);
            return dataAddressIndex;
        }
        private void SetNextAddress(DataTypes type)
        {
            var byteLocation = _addressIndex.ByteLocation;
            var bitIndex = _addressIndex.BitIndex;
            var newBitIndex = bitIndex + (int)type;
            if (newBitIndex > 7)
            {
                byteLocation += 1;
                newBitIndex = newBitIndex - 8;
            }
            _addressIndex = new MemoryLocation(byteLocation, newBitIndex);
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
