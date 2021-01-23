    using System;
    using CGPoint = System.Drawing.PointF;
    using Foundation;
    using UIKit;
    
    namespace myNS
    {
        public class DragDropGestureRecognizer : UIGestureRecognizer
        {
            public DragDropGestureRecognizer()
            {
            }
            
            public event EventHandler<DragDropEventArgs> Held;
            protected void OnHeld(object sender, DragDropEventArgs e)
            {
                if (Held != null)
                    Held(sender, e);
            }
        
            public event EventHandler<DragDropEventArgs> Dragging;
            protected void OnDragging(object sender, DragDropEventArgs e)
            {
                if (Dragging != null)
                    Dragging(sender, e);
            }
        
        
            public event EventHandler<DragDropEventArgs> Dropped;
            protected void OnDropped(object sender, DragDropEventArgs e)
            {
                if (Dropped != null)
                    Dropped(sender, e);
            }
        
            public bool DidDrag { get; private set; }
            public CGPoint DownAt { get; private set; }
            public CGPoint DragAt { get; private set; }
            public CGPoint ViewWasAt { get; private set; }
            public CGPoint Delta
            {
                get { return new CGPoint(DragAt.X - DownAt.X, DragAt.Y - DownAt.Y); }
            }
            public bool Active { get { return DidDrag; } }
            public override UIGestureRecognizerState State
            {
                get { return base.State; }
                set { base.State = value; }
            }
            private CGPoint TouchPoint { get { return (CGPoint)LocationInView(View.Superview); } }
        
            public override bool CanBePreventedByGestureRecognizer(UIGestureRecognizer preventingGestureRecognizer)
            {
                return false;
            }
        
            public override void TouchesBegan(NSSet touches, UIEvent evt)
            {
                base.TouchesBegan(touches, evt);
        
                if (NumberOfTouches > 1)
                {
                    State = UIGestureRecognizerState.Failed;
                    return;
                }
                
                OnHeld(this, new DragDropEventArgs(default(UIGestureRecognizerState), DragAt, Delta, ViewWasAt));
        
                DownAt = TouchPoint;
                ViewWasAt = (CGPoint)View.Center;
                State = UIGestureRecognizerState.Possible;
            }
        
            public override void TouchesEnded(NSSet touches, UIEvent evt)
            {
                base.TouchesEnded(touches, evt);
        
                if (DidDrag)
                {
                    State = UIGestureRecognizerState.Recognized;
                    OnDropped(this, new DragDropEventArgs(State, DragAt, Delta, ViewWasAt));
                }
                else
                    State = UIGestureRecognizerState.Failed;
            }
        
            public override void TouchesCancelled(NSSet touches, UIEvent evt)
            {
                base.TouchesCancelled(touches, evt);
                State = UIGestureRecognizerState.Failed;
            }
        
            public override void TouchesMoved(NSSet touches, UIEvent evt)
            {
                base.TouchesMoved(touches, evt);
                if (State == UIGestureRecognizerState.Failed)
                    return;
        
                DragAt = TouchPoint;
                if (Distance(DownAt, DragAt) > 30 || DidDrag) //Won't move until dragged further than 30px
                {
                    DidDrag = true;
                    OnDragging(this, new DragDropEventArgs(State, DragAt, Delta, ViewWasAt));
                    State = UIGestureRecognizerState.Changed;
                }
            }
        
            public override void Reset()
            {
                base.Reset();
        
                State = UIGestureRecognizerState.Possible;
                DownAt = CGPoint.Empty;
                DragAt = CGPoint.Empty;
                DidDrag = false;
            }
            
            private float Distance(CGPoint point1, CGPoint point2)
            {
                var dx = point1.X - point2.X;
                var dy = point1.Y - point2.Y;
                return (float)Math.Sqrt(dx * dx + dy * dy);
            }
        }
        
        public class DragDropEventArgs : EventArgs
        {
            public DragDropEventArgs(UIGestureRecognizerState state, CGPoint point, CGPoint delta, CGPoint viewWasAt)
            {
                State = state;
                Point = point;
                Delta = delta;
                ViewWasAt = viewWasAt;
            }
        
            public UIGestureRecognizerState State { get; private set; }
            public CGPoint Point { get; private set; }
            public CGPoint Delta { get; private set; }
            public CGPoint ViewWasAt { get; private set; }
        }
    }
