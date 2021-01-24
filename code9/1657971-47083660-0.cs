    [StructLayout(LayoutKind.Explicit)]
    public struct Vertex 
    {
      [FieldOffset(0)]
      public Single X;
      [FieldOffset(4)] // Single uses 4 bytes
      public Single Y;
      [FieldOffset(8)]
      public Single Z;
      [FieldOffset(0)] // This points to the start of the array :)
      public Single[] Position;
    }
