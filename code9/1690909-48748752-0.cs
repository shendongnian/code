    public class MyCustomViewRenderer : ViewRenderer<MyCustomViewControl, MyCustomViewGroup>
    {
        MyCustomViewGroup viewGroup;
        public MyCustomViewRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<MyCustomViewControl> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                viewGroup= new MyCustomViewGroup(Context);
                SetNativeControl(viewGroup);
            }
        }
    }
