            [StructLayout(LayoutKind.Sequential)]
            struct Root
            {
                [MarshalAs(UnmanagedType.Struct, SizeConst = 1000000)]
                Child[] children { get; set; }
            }
            struct Child
            {
                int property1 { get; set; }
                int property2 { get; set; }
                int property3 { get; set; }
                int property4 { get; set; }
                int property5 { get; set; }
                int property6 { get; set; }
            }
