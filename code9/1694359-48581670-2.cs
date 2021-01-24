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
                IntPtr s1Ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(EXT_STRUCT)));
                //use StructureToPtr only when sending values to c++
                Marshal.StructureToPtr(s1, s1Ptr, true);
                int size1 = Marshal.SizeOf(s1); ;
                STRUCT s2 = new STRUCT();
                s2.externalAttribute = new EXT_STRUCT();
                IntPtr s2Ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(STRUCT)));
                //use StructureToPtr only when sending values to c++
                Marshal.StructureToPtr(s2, s2Ptr, true);
                int size2 = Marshal.SizeOf(s2);
                STRUCT s3 = new STRUCT();
                IntPtr s3Ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(STRUCT)));
                //call c++
                Marshal.PtrToStructure(s3Ptr, s3); 
     
            }
