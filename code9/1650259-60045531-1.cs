        public Geometry GetGeometry(Shape s)
        {
            var g = s.RenderedGeometry.Clone();
            g.Transform = GetFullTransform(s);
            return g;
        }
