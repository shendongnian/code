    using System.Runtime.InteropServices   //must be on top of cs file
            
    [StructLayout(LayoutKind.Explicit)]
     struct Converter
            {
                [FieldOffset(0)]
                public byte[] Bytes;
                [FieldOffset(0)]
                public ushort[] Ushorts;
            }
     static byte[] ArrayUshort2Byte(ushort[] input)
            {
                Converter translate = new Converter();
                translate.Ushorts = input;
                return translate.Bytes;
            }
