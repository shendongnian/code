    using System;
    using System.ComponentModel;
    using Xamarin.Forms;
    using CoreGraphics;
    using Foundation;
    using UIKit;
    using System.Collections.Generic;
    using Xamarin.Forms.Platform.iOS;
    using PointF = CoreGraphics.CGPoint;
    using RectangleF = CoreGraphics.CGRect;
    using XColor = Xamarin.Forms.Color;
    using Image = Xamarin.Forms.Image;
    
    public class TouchImage : Image
            {
                public TouchImage() : base() {
                    BackgroundColor = DefaultColor; CurrentLineColor = XColor.Black; Ready += () => IsReady = true;
                }
                public static readonly BindableProperty CurrentLineColorProperty =
                    BindableProperty.Create("CurrentLineColor", typeof(XColor), typeof(TouchImage), XColor.Black);
                public static XColor DefaultColor = XColor.Transparent;
    
                public XColor CurrentLineColor
                {
                    get
                    {
                        return (XColor)GetValue(CurrentLineColorProperty);
                    }
                    set
                    {
                        SetValue(CurrentLineColorProperty, value);
                    }
                }
    
                public void Clear() => WaitExecute(() => ClearEvent?.Invoke());
                public void WaitExecute(Action Task) { if(IsReady) Task(); else Ready += () => Task(); }
                protected internal event Action Ready;
                protected internal bool IsReady;
                protected internal event Action ClearEvent;
    
                public event EventHandler<PointerEventArgs> PointerEvent;
                public class PointerEventArgs : EventArgs
                {
                    public enum PointerEventType : byte { Down, Up, Move, Cancel }
                    public PointerEventType Type { get; }
                    public Point Previous { get; }
                    public Point Current { get; }
                    public bool PointerDown { get; }
                    public PointerEventArgs(PointerEventType Type, Point Previous, Point Current, bool Down) : base()
                    { this.Type = Type; this.Previous = Previous; this.Current = Current; PointerDown = Down; }
                }
                
                public class Renderer : ViewRenderer<TouchImage, DrawView>
                {
                    protected override void OnElementChanged(ElementChangedEventArgs<TouchImage> e)
                    {
                        base.OnElementChanged(e);
                        try
                        {
                            var Draw = DrawView.Create(new Size(e.NewElement.Width, e.NewElement.Height));
                            e.NewElement.ClearEvent = Draw.Clear;
                            Draw.PointerEvent = e.NewElement.PointerEvent;
                            e.NewElement.Ready();
                            SetNativeControl(Draw);
                        } catch (NullReferenceException) { }
                    }
    
                    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
                    {
                        base.OnElementPropertyChanged(sender, e);
    
                        if (e.PropertyName == CurrentLineColorProperty.PropertyName)
                        Control.CurrentLineColor = Element.CurrentLineColor.
                            ToUIColor
                                ();
                        else if(e.PropertyName == BackgroundColorProperty.PropertyName)
                            Control.
                                BackgroundColor =
                                Element.BackgroundColor.ToUIColor()
                                 ;
                    }
                }
            // Original Source: http://stackoverflow.com/questions/21029440/xamarin-ios-drawing-onto-image-after-scaling-it
            public class DrawView : UIView
            {
                public static DrawView Create(Size Size) => new DrawView(new RectangleF(PointF.Empty, Size.ToSizeF()));
                public DrawView(RectangleF frame) : base(frame)
                {
                    DrawPath = new CGPath();
                    CurrentLineColor = UIColor.Black;
                    PenWidth = 5.0f;
                    Lines = new List<VESLine>();
                }
                private PointF PreviousPoint;
                private CGPath DrawPath;
                private byte IndexCount;
                private UIBezierPath CurrentPath;
                private List<VESLine> Lines;
                public UIColor CurrentLineColor { get; set; }
                public float PenWidth { get; set; }
                
                public event DrawDelegate DrawEvent;
                public delegate void DrawDelegate(RectangleF rect);
              
                public void Clear()
                {
                    DrawPath.Dispose();
                    DrawPath = new CGPath();
                    SetNeedsDisplay();
                }
                bool PointerDown;
                internal EventHandler<PointerEventArgs> PointerEvent;
                public override void TouchesBegan(NSSet touches, UIEvent evt)
                {
                    IndexCount++;
                    var path = new UIBezierPath
                    {
                        LineWidth = PenWidth
                    };
                    var touch = (UITouch)touches.AnyObject;
                    PreviousPoint = touch.PreviousLocationInView(this);
                    var newPoint = touch.LocationInView(this);
                    path.MoveTo(newPoint);
                    InvokeOnMainThread(SetNeedsDisplay);
                    CurrentPath = path;
                    var line = new VESLine
                    {
                        Path = CurrentPath,
                        Color = CurrentLineColor,
                        Index = IndexCount
                    };
                    Lines.Add(line);
                    PointerDown = true;
                    PointerEvent?.Invoke(this, new PointerEventArgs(PointerEventArgs.
                         PointerEventType.Down, PreviousPoint.ToPoint(), newPoint.ToPoint(), PointerDown));
                }
                public override void TouchesMoved(NSSet touches, UIEvent evt)
                {
                    var touch = (UITouch)touches.AnyObject;
                    var currentPoint = touch.LocationInView(this);
                    if (Math.Abs(currentPoint.X - PreviousPoint.X) >= 4 ||
                        Math.Abs(currentPoint.Y - PreviousPoint.Y) >= 4)
                    {
                        var newPoint = new PointF((currentPoint.X + PreviousPoint.X) / 2,
                            (currentPoint.Y + PreviousPoint.Y) / 2);
                        CurrentPath.AddQuadCurveToPoint(newPoint, PreviousPoint);
                        PreviousPoint = currentPoint;
                        InvokeOnMainThread(SetNeedsDisplay);
                        PointerEvent?.Invoke(this, new PointerEventArgs(PointerEventArgs.
                             PointerEventType.Move, PreviousPoint.ToPoint(), newPoint.ToPoint(), PointerDown));
                    }
                    else
                    {
                        CurrentPath.AddLineTo(currentPoint);
                        InvokeOnMainThread(SetNeedsDisplay);
                    }
                }
                public override void TouchesEnded(NSSet touches, UIEvent evt)
                {
                    RaisePointerEvent(touches, PointerEventArgs.PointerEventType.Up, PointerDown = false);
                }
                public override void TouchesCancelled(NSSet touches, UIEvent evt)
                {
                    RaisePointerEvent(touches, PointerEventArgs.PointerEventType.Cancel, PointerDown = false);
                }
                public void RaisePointerEvent(NSSet touches, PointerEventArgs.PointerEventType Type, bool PointerDown)
                {
                    var touch = (UITouch)touches.AnyObject;
                    PreviousPoint = touch.PreviousLocationInView(this);
                    var newPoint = touch.LocationInView(this);
                    InvokeOnMainThread(SetNeedsDisplay);
                    PointerEvent?.Invoke(this, new PointerEventArgs(Type,
                        PreviousPoint.ToPoint(), newPoint.ToPoint(), PointerDown));
                }
                public override void Draw(RectangleF rect)
                {
                    foreach (var line in Lines)
                    {
                        line.Color.SetStroke();
                        line.Path.Stroke();
                    }
                    DrawEvent(rect);
                }
            }
            public class VESLine
            {
                public UIBezierPath Path
                {
                    get;
                    set;
                }
                public UIColor Color
                {
                    get;
                    set;
                }
                public byte Index
                {
                    get;
                    set;
                }
            }
