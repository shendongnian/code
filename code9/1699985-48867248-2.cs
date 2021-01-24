    using System.Runtime.InteropServices   //must be on top of cs file
            
    [StructLayout(LayoutKind.Explicit)]
     struct Converter
            {
                [FieldOffset(0)]
                public byte[] Bytes;     //warning bytes are 8 bit ! dont use
                [FieldOffset(0)]
                public ushort[] Ushorts;  //16bit
                [FieldOffset(0)]
                public char[] Chars;      //16bit
            }
     static byte[] ArrayUshort2Byte(ushort[] input)
            {
                Converter translate = new Converter();
                translate.Ushorts = input;
                return translate.Bytes;
            }
     static char[] ArrayUshort2Char(ushort[] input)
            {
                //without any buffer copying i convert types 
                //not even convert.ushort overhead no overhead here..
        
                Converter translate = new Converter();
                translate.Ushorts = input;
                return translate.Chars;
            }
