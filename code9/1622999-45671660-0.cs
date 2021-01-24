    // Represents a Globally Unique Identifier.
    public struct Guid : IFormattable, IComparable,
                         IComparable<Guid>, IEquatable<Guid> {
        //  Member variables
        private int         _a; // <<== First group,  4 bytes
        private short       _b; // <<== Second group, 2 bytes
        private short       _c; // <<== Third group,  2 bytes
        private byte       _d;
        private byte       _e;
        private byte       _f;
        private byte       _g;
        private byte       _h;
        private byte       _i;
        private byte       _j;
        private byte       _k;
        ...
    }
