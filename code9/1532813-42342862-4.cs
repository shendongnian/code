    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    namespace InsertNamespaceHere
    {
        public class NiceCornersControl : ContentControl
        {
            public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
                "Stroke", typeof(Brush), typeof(NiceCornersControl), new PropertyMetadata(default(Brush), OnVisualPropertyChanged));
            public Brush Stroke
            {
                get { return (Brush)GetValue(StrokeProperty); }
                set { SetValue(StrokeProperty, value); }
            }
            public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
                "StrokeThickness", typeof(double), typeof(NiceCornersControl), new PropertyMetadata(default(double), OnVisualPropertyChanged));
            public double StrokeThickness
            {
                get { return (double)GetValue(StrokeThicknessProperty); }
                set { SetValue(StrokeThicknessProperty, value); }
            }
            public static readonly DependencyProperty StrokeDashLineProperty = DependencyProperty.Register(
                "StrokeDashLine", typeof(double), typeof(NiceCornersControl), new PropertyMetadata(default(double), OnVisualPropertyChanged));
            public double StrokeDashLine
            {
                get { return (double)GetValue(StrokeDashLineProperty); }
                set { SetValue(StrokeDashLineProperty, value); }
            }
            public static readonly DependencyProperty StrokeDashSpaceProperty = DependencyProperty.Register(
                "StrokeDashSpace", typeof(double), typeof(NiceCornersControl), new PropertyMetadata(default(double), OnVisualPropertyChanged));
            public double StrokeDashSpace
            {
                get { return (double)GetValue(StrokeDashSpaceProperty); }
                set { SetValue(StrokeDashSpaceProperty, value); }
            }
            public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
                "Fill", typeof(Brush), typeof(NiceCornersControl), new PropertyMetadata(default(Brush), OnVisualPropertyChanged));
            public Brush Fill
            {
                get { return (Brush)GetValue(FillProperty); }
                set { SetValue(FillProperty, value); }
            }
            private static void OnVisualPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((NiceCornersControl)d).InvalidateVisual();
            }
            public NiceCornersControl()
            {
                SnapsToDevicePixels = true;
                UseLayoutRounding = true;
            }
            protected override void OnRender(DrawingContext drawingContext)
            {
                double w = ActualWidth;
                double h = ActualHeight;
                double x = StrokeThickness / 2.0;
                Pen horizontalPen = GetPen(ActualWidth - 2.0 * x);
                Pen verticalPen = GetPen(ActualHeight - 2.0 * x);
                drawingContext.DrawRectangle(Fill, null, new Rect(new Point(0, 0), new Size(w, h)));
                drawingContext.DrawLine(horizontalPen, new Point(x, x), new Point(w - x, x));
                drawingContext.DrawLine(horizontalPen, new Point(x, h - x), new Point(w - x, h - x));
                drawingContext.DrawLine(verticalPen, new Point(x, x), new Point(x, h - x));
                drawingContext.DrawLine(verticalPen, new Point(w - x, x), new Point(w - x, h - x));
            }
            private Pen GetPen(double length)
            {
                IEnumerable<double> dashArray = GetDashArray(length);
                return new Pen(Stroke, StrokeThickness)
                {
                    DashStyle = new DashStyle(dashArray, 0),
                    EndLineCap = PenLineCap.Square,
                    StartLineCap = PenLineCap.Square,
                    DashCap = PenLineCap.Flat
                };
            }
            private IEnumerable<double> GetDashArray(double length)
            {
                double useableLength = length - StrokeDashLine;
                int lines = (int)Math.Round(useableLength / (StrokeDashLine + StrokeDashSpace));
                useableLength -= lines * StrokeDashLine;
                double actualSpacing = useableLength / lines;
                yield return StrokeDashLine / StrokeThickness;
                yield return actualSpacing / StrokeThickness;
            }
        }
    }
