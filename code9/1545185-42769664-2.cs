	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Windows;
	using System.Windows.Media;
	using System.Windows.Shapes;
	namespace LineCaps
	{
		
		public class CappedLine: FrameworkElement
		{        
			protected override void  OnRender(DrawingContext dc)
			{
				Point pos, tangent;
				double angleInRadians;
				double angleInDegrees;
				TransformGroup tg;
				Pen pen = new Pen(Stroke, StrokeThickness);
				dc.DrawGeometry(null, pen, LinePath);
				Pen capPen = new Pen(CapStroke, CapStrokeThickness);
				if (BeginCap != null)
				{
					LinePath.GetPointAtFractionLength(0.01d, out pos, out tangent);
					angleInRadians = Math.Atan2(tangent.Y, tangent.X) + Math.PI;
					angleInDegrees = angleInRadians * 180 / Math.PI + 180;
					tg = new TransformGroup();
					tg.Children.Add(new RotateTransform(angleInDegrees));
					LinePath.GetPointAtFractionLength(0.0d, out pos, out tangent);
					tg.Children.Add(new TranslateTransform(pos.X, pos.Y));
					dc.PushTransform(tg);
					dc.DrawGeometry(CapStroke, capPen, BeginCap);
					dc.Pop();
				}
				if (EndCap != null)
				{
					LinePath.GetPointAtFractionLength(0.99, out pos, out tangent);
					angleInRadians = Math.Atan2(tangent.Y, tangent.X) + Math.PI;
					angleInDegrees = angleInRadians * 180 / Math.PI;
					tg = new TransformGroup();
					tg.Children.Add(new RotateTransform(angleInDegrees));
					LinePath.GetPointAtFractionLength(1, out pos, out tangent);
					tg.Children.Add(new TranslateTransform(pos.X, pos.Y));
					dc.PushTransform(tg);
					dc.DrawGeometry(CapStroke, capPen, EndCap);
				}         
			}
			protected override Size MeasureOverride(Size availableSize)
			{
				//TODO: Consider creating the Pen once when Stroke and StrokeThickness are set
				return LinePath.GetRenderBounds(new Pen(Stroke, StrokeThickness)).Size;
			}
			public static readonly DependencyProperty StrokeProperty = Shape.StrokeProperty.AddOwner(typeof(CappedLine));
			public Brush Stroke
			{
				get { return (Brush)GetValue(StrokeProperty); }
				set { SetValue(StrokeProperty, value); }
			}
			
			public static readonly DependencyProperty StrokeThicknessProperty = Shape.StrokeThicknessProperty.AddOwner(typeof(CappedLine));
			public double StrokeThickness
			{
				get { return (double)GetValue(StrokeThicknessProperty); }
				set { SetValue(StrokeThicknessProperty, value); }
			}
			public static DependencyProperty CapStrokeProperty =
			DependencyProperty.Register(
				"CapStroke",
				typeof(Brush),
				typeof(CappedLine));
			public Brush CapStroke
			{
				get { return (Brush)GetValue(CapStrokeProperty); }
				set { SetValue(CapStrokeProperty, value); }
			}
			public static readonly DependencyProperty CapStrokeThicknessProperty =
			DependencyProperty.Register(
				"CapStrokeThickness",
				typeof(double),
				typeof(CappedLine));
			
			public double CapStrokeThickness
			{
				get { return (double)GetValue(CapStrokeThicknessProperty); }
				set { SetValue(StrokeThicknessProperty, value); }
			}
			public static readonly DependencyProperty LinePathProperty =
				DependencyProperty.Register("LinePath", typeof(PathGeometry), typeof(CappedLine),
				new FrameworkPropertyMetadata(
					null,
					FrameworkPropertyMetadataOptions.AffectsRender, // choose appropriate flags here!!!
					LinePathChangedCallback));
			static void LinePathChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs args)
			{
				CappedLine me = sender as CappedLine;
				if (null != me)
				{
					me.OnLinePathChanged((PathGeometry)args.NewValue);
				}
			}
			public PathGeometry LinePath
			{
				get { return (PathGeometry)GetValue(LinePathProperty); }
				set { SetValue(LinePathProperty, value); }
			}
			public virtual void OnLinePathChanged(PathGeometry value)
			{
			}
			public static readonly DependencyProperty BeginCapProperty =
				DependencyProperty.Register("BeginCap", typeof(Geometry), typeof(CappedLine),
				new FrameworkPropertyMetadata(
					null,
					FrameworkPropertyMetadataOptions.AffectsRender, // choose appropriate flags here!!!
					BeginCapChangedCallback));
			static void BeginCapChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs args)
			{
				CappedLine me = sender as CappedLine;
				if (null != me)
				{
					me.OnBeginCapChanged((Geometry)args.NewValue);
				}
			}
			public Geometry BeginCap
			{
				get { return (Geometry)GetValue(BeginCapProperty); }
				set { SetValue(BeginCapProperty, value); }
			}
			public virtual void OnBeginCapChanged(Geometry value)
			{
			}
			public static readonly DependencyProperty EndCapProperty =
				DependencyProperty.Register("EndCap", typeof(Geometry), typeof(CappedLine),
				new FrameworkPropertyMetadata(
					null,
					FrameworkPropertyMetadataOptions.AffectsRender, // choose appropriate flags here!!!
					EndCapChangedCallback));
			static void EndCapChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs args)
			{
				CappedLine me = sender as CappedLine;
				if (null != me)
				{
					me.OnEndCapChanged((Geometry)args.NewValue);
				}
			}
			public Geometry EndCap
			{
				get { return (Geometry)GetValue(EndCapProperty); }
				set { SetValue(EndCapProperty, value); }
			}
			public virtual void OnEndCapChanged(Geometry value)
			{
			}
		}
	}
