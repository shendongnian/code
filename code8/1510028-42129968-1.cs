     class PdfWord
        {
            public float StartX { get; set; }
            public float EndX { get; set; }
            public float Y { get; set; }
            public float StartCharWidth { get; set; }
            public float EndCharWidth { get; set; }
            public float Height { get; set; }
            public string Text { get; set; }
            public float Right { get { return EndX + EndCharWidth; } }
        }
