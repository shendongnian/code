    namespace PdfSharp.Pdf.Annotations
    {
        using Extensions;
        using System.Collections.Generic;
    
        public class PdfHighlightAnnotation : PdfMarkupAnnotation
        {
            public PdfHighlightAnnotation()
            {
                Initialize();
            }
    
            public PdfHighlightAnnotation(PdfDocument document)
                : base(document)
            {
                Initialize();
            }
    
            void Initialize()
            {
                Elements.SetName(Keys.Subtype, "/Highlight");
            }
        }
    
        public class PdfStrikeOutAnnotation : PdfMarkupAnnotation
        {
            public PdfStrikeOutAnnotation()
            {
                Initialize();
            }
    
            public PdfStrikeOutAnnotation(PdfDocument document)
                : base(document)
            {
                Initialize();
            }
    
            void Initialize()
            {
                Elements.SetName(Keys.Subtype, "/StrikeOut");
            }
        }
    
        public abstract class PdfMarkupAnnotation : PdfAnnotation
        {
            protected PdfMarkupAnnotation()
            { }
    
            protected PdfMarkupAnnotation(PdfDocument document)
                : base(document)
            { }
    
            public IEnumerable<PdfRectangle> Quadrilaterals
            {
                set {
                    var points = new PdfArray();
                    foreach (var r in value) {
                        points.Elements.AddRange(ToQuadPoints(r));
                    }
                    Elements.SetValue("/QuadPoints", points);
                }
            }
    
            private IEnumerable<PdfItem> ToQuadPoints(PdfRectangle r)
            {
                // Conversion from PdfRectangle coordinates
                //
                // Y ^
                //   |                     (X2 Y2)
                //   |        +-----------+
                //   |        |           |
                //   |        |           |
                //   |        +-----------+
                //   | (X1 Y1)
                //   |                              
                //   +-----------------------------> 
                //                                 X
                // to QuadPoints coordinates (x1 y1 x2 y2 x3 y3 x4 y4)
                //
                // Y ^
                //   | (x4 y4)             (x3 y3)
                //   |        +-----------+
                //   |        |           |
                //   |        |           |
                //   |        +-----------+
                //   | (x1 y1)             (x2 y2)
                //   |                              
                //   +-----------------------------> 
                //                                 X
                //
                return new List<PdfItem> { new PdfReal(r.X1), new PdfReal(r.Y1),
                                           new PdfReal(r.X2), new PdfReal(r.Y1),
                                           new PdfReal(r.X1), new PdfReal(r.Y2),
                                           new PdfReal(r.X2), new PdfReal(r.Y2)};
            }
        }
    }
    
    namespace PdfSharp.Extensions
    {
        using PdfSharp.Pdf;
        using System.Collections.Generic;
    
        public static class ArrayElementsExtensions
        {
            public static void AddRange(this PdfArray.ArrayElements elements, IEnumerable<PdfItem> values)
            {
                foreach (var v in values) {
                    elements.Add(v);
                }
            }
        }
    }
