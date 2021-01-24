    public class DraggableContentViewRenderer : ViewRenderer<DraggableContentView, UIView>
    {
        private CGPoint _offsetLocation;
    
        protected override void OnElementChanged(ElementChangedEventArgs<DraggableContentView> e)
        {
            base.OnElementChanged(e);
    
            if (Element != null)
            {
                if (Control == null)
                {
                    SetNativeControl(new UIView());
                }
            }
        }
    
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
    
            var t = touches.ToArray<UITouch>();
            if (t.Length != 1) 
                return;
                
            var loc = t[0].LocationInView(this);
    
            var touchedView = HitTest(loc, evt);
            if (touchedView == null) 
                return;
    
            _offsetLocation = new CGPoint(loc.X - touchedView.Frame.X, loc.Y - touchedView.Frame.Y);
    
            Element.InvokeTouchBegan();
        }
                
        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
    
            var newLoc = ((UITouch)touches.First()).LocationInView(this);
            Element.TranslationX += newLoc.X - _offsetLocation.X;
            Element.TranslationY += newLoc.Y - _offsetLocation.Y;
            Element.InvokePositionChanged();
        }
    
        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
    
            Element.InvokeTouchEnded();
        }
    }
