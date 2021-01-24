    using System;
    using System.Runtime.InteropServices;
    
    
    
    namespace SockStructTest
    {
        class Program
        {
            [StructLayout(LayoutKind.Explicit, Size = 8)]
            public struct struct_sin_zero
            {
                [FieldOffset(0)]
                public byte s_b1;
                [FieldOffset(1)]
                public byte s_b2;
                [FieldOffset(2)]
                public byte s_b3;
                [FieldOffset(3)]
                public byte s_b4;
                [FieldOffset(4)]
                public byte s_b5;
                [FieldOffset(5)]
                public byte s_b6;
                [FieldOffset(6)]
                public byte s_b7;
                [FieldOffset(7)]
                public byte s_b8;
    
                [FieldOffset(0)]
                public UInt64 s_ui64;
            };
    
    
    
            [StructLayout(LayoutKind.Explicit, Size = 4)]
            public struct in_addr
            {
                [FieldOffset(0)]
                public byte s_b1;
                [FieldOffset(1)]
                public byte s_b2;
                [FieldOffset(2)]
                public byte s_b3;
                [FieldOffset(3)]
                public byte s_b4;
    
                [FieldOffset(0)]
                public UInt16 s_w1;
                [FieldOffset(2)]
                public UInt16 s_w2;
    
                [FieldOffset(0)]
                public UInt32 S_addr;
            };
    
    
            [StructLayout(LayoutKind.Explicit, Size = 16)]
            public struct sockaddr_in
            {
                [FieldOffset(0)]
                public Int16 sin_family;
    
                [FieldOffset(2)]
                public UInt16 sin_port;
    
                [FieldOffset(4)]
                public in_addr sin_addr;  
    
                [FieldOffset(8)]
                public struct_sin_zero sin_zero;
            };
    
    
    
    
            [StructLayout(LayoutKind.Explicit, Size = 16)]
            public struct in6_addr_u
            {
                [FieldOffset(0)]
                public byte Byte0;
                [FieldOffset(1)]
                public byte Byte1;
                [FieldOffset(2)]
                public byte Byte2;
                [FieldOffset(3)]
                public byte Byte3;
                [FieldOffset(4)]
                public byte Byte4;
                [FieldOffset(5)]
                public byte Byte5;
                [FieldOffset(6)]
                public byte Byte6;
                [FieldOffset(7)]
                public byte Byte7;
                [FieldOffset(8)]
                public byte Byte8;
                [FieldOffset(9)]
                public byte Byte9;
                [FieldOffset(10)]
                public byte ByteA;
                [FieldOffset(11)]
                public byte ByteB;
                [FieldOffset(12)]
                public byte ByteC;
                [FieldOffset(13)]
                public byte ByteD;
                [FieldOffset(14)]
                public byte ByteE;
                [FieldOffset(15)]
                public byte ByteF;
    
                [FieldOffset(0)]
                public UInt16 Word0;
                [FieldOffset(2)]
                public UInt16 Word1;
                [FieldOffset(4)]
                public UInt16 Word2;
                [FieldOffset(6)]
                public UInt16 Word3;
                [FieldOffset(8)]
                public UInt16 Word4;
                [FieldOffset(10)]
                public UInt16 Word5;
                [FieldOffset(12)]
                public UInt16 Word6;
                [FieldOffset(14)]
                public UInt16 Word7;
            }
    
            [StructLayout(LayoutKind.Explicit, Size = 16)]
            public struct in6_addr
            {
                [FieldOffset(0)]
                public in6_addr_u u;
            }
    
    
            [StructLayout(LayoutKind.Sequential, Pack = 4)]
            public struct sockaddr_in6
            {
                public UInt64  sin6_len;            //  length of this struct(sa_family_t)
    
                public UInt32  sin6_family;         //  AF_INET6 (sa_family_t)
    
                public UInt16   sin6_port;          //  Transport layer port # (in_port_t)
    
                public UInt32   sin6_flowinfo;      //  IP6 flow information
    
                public in6_addr sin6_addr;          //  IP6 address
    
                public UInt32   sin6_scope_id;      //  scope zone index
            };
    
    
            [StructLayout(LayoutKind.Explicit, Size = 16)]
            public struct res_sockaddr_union
            {
                [FieldOffset(0)]
                public sockaddr_in sin;
    
                [FieldOffset(0)]
                public sockaddr_in6 sin6;
    
                [FieldOffset(0)]
                public Int64 __align64;
    
                [FieldOffset(0)]
                public Int32 __align32;
    
                // This is the char __space[128] bit.
                // I've cheated and used 16 8 byte values.
                [FieldOffset(0)]
                public UInt64 __space0;
                [FieldOffset(8)]
                public UInt64 __space1;
                [FieldOffset(16)]
                public UInt64 __space2;
                [FieldOffset(24)]
                public UInt64 __space3;
                [FieldOffset(32)]
                public UInt64 __space4;
                [FieldOffset(40)]
                public UInt64 __space5;
                [FieldOffset(48)]
                public UInt64 __space6;
                [FieldOffset(56)]
                public UInt64 __space7;
                [FieldOffset(64)]
                public UInt64 __space8;
                [FieldOffset(72)]
                public UInt64 __space9;
                [FieldOffset(80)]
                public UInt64 __spaceA;
                [FieldOffset(88)]
                public UInt64 __spaceB;
                [FieldOffset(96)]
                public UInt64 __spaceC;
                [FieldOffset(104)]
                public UInt64 __spaceD;
                [FieldOffset(112)]
                public UInt64 __spaceE;
                [FieldOffset(120)]
                public UInt64 __spaceF;
            }
    
    
    
            static void Main(string[] args)
            {
                sockaddr_in ad;
    
                ad.sin_zero.s_ui64 = 0;
    
                ad.sin_family = 0; // or whatever
    
                ad.sin_port = 1234;
    
                // Address as b bit values
                ad.sin_addr.s_b1 = 0;
                ad.sin_addr.s_b2 = 1;
                ad.sin_addr.s_b3 = 2;
                ad.sin_addr.s_b4 = 3;
    
                // Address as 16 bits
                ad.sin_addr.s_w1 = 0;
                ad.sin_addr.s_w2 = 0;
            }
        }
    }
