           [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct EXT_STRUCT //External attribute
            {
                public byte innerAttribute; //The inner attribute being modified
                public byte innerAttribute2; //Another inner attribute having exactly the same issue
            }
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct STRUCT
            {
                public int i1;
                public int i2;
                public int i3;
                public EXT_STRUCT externalAttribute;
            }
            static void Main(string[] args)
            {
                EXT_STRUCT s1 = new EXT_STRUCT();
                int size1 = Marshal.SizeOf(s1); ;
                STRUCT s2 = new STRUCT();
                s2.externalAttribute = new EXT_STRUCT();
                int size2 = Marshal.SizeOf(s2);
     
            }
