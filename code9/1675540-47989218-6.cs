    [assembly: ExportRenderer(typeof(ButtonWithLongPressGesture), typeof(LongPressGestureRecognizerButtonRenderer))]
    namespace ImageWrapLayout.iOS
    {
    class LongPressGestureRecognizerButtonRenderer : ButtonRenderer
    {
        ButtonWithLongPressGesture view;
        public LongPressGestureRecognizerButtonRenderer()
        {
            this.AddGestureRecognizer(new UILongPressGestureRecognizer((longPress) => {
                if (longPress.State == UIGestureRecognizerState.Began)
                {
                    view.HandleLongPress(view, new EventArgs());
                }
            }));
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                view = e.NewElement as ButtonWithLongPressGesture;
            //if(Control == null)
            //{
            UIButton but = Control as UIButton;
                but.TouchUpInside += (sender, e1) => {
                    view.HandleTap(view, new EventArgs());
                };
            //}
        }
    }
    }
