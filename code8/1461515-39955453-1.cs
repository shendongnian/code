    public class House : IProvideSizes
    {
        public const int _sizeX = 4;
        public const int _sizeY = 4;
        public int SizeX { get { return _sizeX; } }
        public int SizeY { get { return _sizeY; } }
    }
    public class House1 : IProvideSizes
    {
        public const int _sizeX = 6;
        public const int _sizeY = 6;
        public int SizeX { get { return _sizeX; } }
        public int SizeY { get { return _sizeY; } }
    }
    public class Commercial : IProvideSizes
    {
        public const int _sizeX = 10;
        public const int _sizeY = 10;
        public int SizeX { get { return _sizeX; } }
        public int SizeY { get { return _sizeY; } }
    }
