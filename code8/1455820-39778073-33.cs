    namespace WpfExampleControlLibrary
    {
        public class GraphPen : DependencyObject
        {
            #region Constructor
    
            public GraphPen()
            {
                PenGeometry = new PathGeometry();
            }
    
            #endregion Constructor
    
            #region Dependency Properties
    
            // Line Color
    
            public static PropertyMetadata PenLineColorPropertyMetadata
                = new PropertyMetadata(null);
            public static DependencyProperty PenLineColorProperty
                = DependencyProperty.Register(
                    "PenLineColor",
                    typeof(Brush),
                    typeof(GraphPen),
                    PenLineColorPropertyMetadata);
            public Brush PenLineColor
            {
                get { return (Brush)GetValue(PenLineColorProperty); }
                set { SetValue(PenLineColorProperty, value); }
            }
    
            // Line Thickness
    
            public static PropertyMetadata PenLineThicknessPropertyMetadata
                = new PropertyMetadata(null);
            public static DependencyProperty PenLineThicknessProperty
                = DependencyProperty.Register(
                    "PenLineThickness",
                    typeof(Int32),
                    typeof(GraphPen),
                    PenLineThicknessPropertyMetadata);
            public Int32 PenLineThickness
            {
                get { return (Int32)GetValue(PenLineThicknessProperty); }
                set { SetValue(PenLineThicknessProperty, value); }
            }
    
            // Pen Geometry
    
            public static PropertyMetadata PenGeometryMetadata = new PropertyMetadata(null);
            public static DependencyProperty PenGeometryProperty
                = DependencyProperty.Register(
                    "PenGeometry",
                    typeof(PathGeometry),
                    typeof(GraphPen),
                    PenGeometryMetadata);
    
            public PathGeometry PenGeometry
            {
                get { return (PathGeometry)GetValue(PenGeometryProperty); }
                set { SetValue(PenGeometryProperty, value); }
            }
    
            #endregion Dependency Properties
        }
    }
