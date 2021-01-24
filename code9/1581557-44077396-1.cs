    using System;
    
    struct FontGlyph 
    {
        public uint codepoint;
        public byte[] bmp;
    }
    
    class Program
    {
        static void Main()
        {
            FontGlyph[] glyphs = new FontGlyph[100];
            RenderFontGlyph(ref glyphs[0]);
            Console.WriteLine(glyphs[0].bmp.Length); // 10
        }
        
        static void RenderFontGlyph(ref FontGlyph glyph)
        {
            glyph.bmp = new byte[10];
        }
    }
