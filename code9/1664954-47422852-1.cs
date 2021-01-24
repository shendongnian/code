    public class DraggableContentViewRenderer : ViewRenderer<DraggableContentView, Android.Views.View>
    {
        private float _density, _downX, _downY;
    
        public DraggableContentViewRenderer()
        {
            _density = Android.App.Application.Context.Resources.DisplayMetrics.Density;
        }
    
        protected override void OnElementChanged(ElementChangedEventArgs<DraggableContentView> e)
        {
            base.OnElementChanged(e);
    
            if (Element != null)
            {
                if (Control == null)
                {
                    SetNativeControl(new Android.Views.View(Xamarin.Forms.Forms.Context));
                }
            }
        }
    
        public override bool DispatchTouchEvent(MotionEvent e)
        {
            if (!Element.IsEnabled)
                return false;
    
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    {
                        _downX = e.GetX();
                        _downY = e.GetY();
                        Element.InvokeTouchBegan();
                        break;
                    }
                case MotionEventActions.Move:
                    {
                        var x = e.GetX();
                        var y = e.GetY();
                        var dx = (x - _downX) / _density;
                        var dy = (y - _downY) / _density;
                        Element.TranslationX += dx;
                        Element.TranslationY += dy;
                        Element.InvokePositionChanged();
                        break;
                    }
                case MotionEventActions.Up:
                case MotionEventActions.Cancel:
                    {
                        Element.InvokeTouchEnded();
                        break;
                    }
                default:
                    break;
            }
            return true;
        }
    }
