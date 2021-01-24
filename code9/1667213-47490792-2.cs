        class GlyphElement : FrameworkElement
        {
            private GlyphRunner gr;
            public GlyphElement(string text, Brush br, Size size) { gr = new GlyphRunner(text, br, size); }
            protected override Visual GetVisualChild(int index) { return gr; }
            protected override int VisualChildrenCount { get { return 1; } }
        }
    
