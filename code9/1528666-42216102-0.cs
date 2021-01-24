    [StructLayout(LayoutKind.Explicit, Pack = 2)]
    public struct VertexO
    {
        public VertexO(Vector location)
        {
            Location = location;
            Neighbours = new IntListO();
            Triangles = new IntListO();
        }
        public VertexO(float x, float y, float z) : this(new Vector(x, y, z)) { }
        [FieldOffset(0)]
        public Vector Location;
        [FieldOffset(sizeof(float) * 3)]
        public IntListO Neighbours;
        #if WIN64
        [FieldOffset(sizeof(float) * 3 + (sizeof(int) * 2 + sizeof(long)))]
        #else
        [FieldOffset(sizeof(float) * 3 + (sizeof(int) * 2 + sizeof(int)))]
        #endif
        public IntListO Triangles;
    }
