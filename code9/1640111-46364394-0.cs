    internal sealed class MembershipSet
    {
        private readonly HashSet<int> _members = new HashSet<int>();
        public void Add(int x, int y, int z)
        {
            _members.Add(Pack(x, y, z));
        }
        public bool Contains(int x, int y, int z)
        {
            return _members.Contains(Pack(x, y, z));
        }
        private static int Pack(int x, int y, int z)
        {
            if (x < 0 || x > 50)
                throw new ArgumentOutOfRangeException(nameof(x));
            if (y < 0 || y > 6)
                throw new ArgumentOutOfRangeException(nameof(y));
            if (z < 0 || z > 6)
                throw new ArgumentOutOfRangeException(nameof(z));
            return x | y << 8 | z << 16;
        }
    }
