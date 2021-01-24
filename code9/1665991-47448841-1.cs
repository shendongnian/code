        //Create this custom view in your Xamarin.Android project.
        public class DragViewNative:View
        {
           public DragViewNative(Context context) : base(context)
           {
           }
           public override bool OnTouchEvent(MotionEvent e)
           {
               //implement your OnTouchEvent logic here
               ...
           }
         ...
        }
        public class DraggableViewRenderer : ViewRenderer
        {
            ...
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
            {
                base.OnElementChanged(e);
                //set native control to be your custom view
                SetNativeControl(new DragViewNative(Xamarin.Forms.Forms.Context));
                //other logic here
            }
        }
