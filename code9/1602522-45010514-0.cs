    class ExtRenderListener : IExtRenderListener
    {
        public void BeginTextBlock() { }
        public void RenderText(TextRenderInfo renderInfo) { }
        public void EndTextBlock() { }
        public void RenderImage(ImageRenderInfo renderInfo) { }
        public void ModifyPath(PathConstructionRenderInfo renderInfo)
        {
            pathInfos.Add(renderInfo);
        }
        public iTextSharp.text.pdf.parser.Path RenderPath(PathPaintingRenderInfo renderInfo)
        {
            GraphicsState graphicsState = getGraphicsState(renderInfo);
            Matrix ctm = graphicsState.GetCtm();
            if ((renderInfo.Operation & PathPaintingRenderInfo.FILL) != 0)
            {
                Console.Write("FILL ({0}) ", toString(graphicsState.FillColor));
                if ((renderInfo.Operation & PathPaintingRenderInfo.STROKE) != 0)
                    Console.Write("and ");
            }
            if ((renderInfo.Operation & PathPaintingRenderInfo.STROKE) != 0)
            {
                Console.Write("STROKE ({0}) ", toString(graphicsState.StrokeColor));
            }
            Console.Write("the path ");
            foreach (PathConstructionRenderInfo pathConstructionRenderInfo in pathInfos)
            {
                switch (pathConstructionRenderInfo.Operation)
                {
                    case PathConstructionRenderInfo.MOVETO:
                        Console.Write("move to {0} ", toString(transform(ctm, pathConstructionRenderInfo.SegmentData)));
                        break;
                    case PathConstructionRenderInfo.CLOSE:
                        Console.Write("close {0} ", toString(transform(ctm, pathConstructionRenderInfo.SegmentData)));
                        break;
                    case PathConstructionRenderInfo.CURVE_123:
                        Console.Write("curve123 {0} ", toString(transform(ctm, pathConstructionRenderInfo.SegmentData)));
                        break;
                    case PathConstructionRenderInfo.CURVE_13:
                        Console.Write("curve13 {0} ", toString(transform(ctm, pathConstructionRenderInfo.SegmentData)));
                        break;
                    case PathConstructionRenderInfo.CURVE_23:
                        Console.Write("curve23 {0} ", toString(transform(ctm, pathConstructionRenderInfo.SegmentData)));
                        break;
                    case PathConstructionRenderInfo.LINETO:
                        Console.Write("line to {0} ", toString(transform(ctm, pathConstructionRenderInfo.SegmentData)));
                        break;
                    case PathConstructionRenderInfo.RECT:
                        Console.Write("rectangle {0} ", toString(transform(ctm, expandRectangleCoordinates(pathConstructionRenderInfo.SegmentData))));
                        break;
                }
            }
            Console.WriteLine();
            pathInfos.Clear();
            return null;
        }
        String toString(IList<float> coordinates)
        {
            StringBuilder result = new StringBuilder();
            result.Append("[ ");
            for (int i = 0; i < coordinates.Count; i++)
            {
                result.Append(coordinates[i]);
                result.Append(' ');
            }
            result.Append(']');
            return result.ToString();
        }
        List<float> transform(Matrix ctm, IList<float> coordinates)
        {
            List<float> result = new List<float>();
            for (int i = 0; i + 1 < coordinates.Count; i += 2)
            {
                Vector vector = new Vector(coordinates[i], coordinates[i + 1], 1);
                vector = vector.Cross(ctm);
                result.Add(vector[Vector.I1]);
                result.Add(vector[Vector.I2]);
            }
            return result;
        }
        List<float> expandRectangleCoordinates(IList<float> rectangle)
        {
            if (rectangle.Count < 4)
                return new List<float>();
            return new List<float>
            {
                    rectangle[0], rectangle[1],
                    rectangle[0] + rectangle[2], rectangle[1],
                    rectangle[0] + rectangle[2], rectangle[1] + rectangle[3],
                    rectangle[0], rectangle[1] + rectangle[3]
            };
        }
        String toString(BaseColor baseColor)
        {
            if (baseColor == null)
                return "DEFAULT";
            return String.Format("{0},{1},{2}", baseColor.R, baseColor.G, baseColor.B);
        }
        GraphicsState getGraphicsState(PathPaintingRenderInfo renderInfo)
        {
            System.Reflection.FieldInfo gsField = typeof(PathPaintingRenderInfo).GetField("gs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (GraphicsState) gsField.GetValue(renderInfo);
        }
        public void ClipPath(int rule)
        {
        }
        List<PathConstructionRenderInfo> pathInfos = new List<PathConstructionRenderInfo>();
    }
