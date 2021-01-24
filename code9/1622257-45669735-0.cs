    [assembly: ExportRenderer(typeof(MyFloatButton), typeof(MyFloatButtonRenderer))]
    
    namespace NameSpace.Droid
    {
        public class MyFloatButtonRenderer : Xamarin.Forms.Platform.Android.ViewRenderer<MyFloatButton, FloatingActionButton>
        {
            private FloatingActionButton fab;
    
            protected override void OnElementChanged(ElementChangedEventArgs<MyFloatButton> e)
            {
                base.OnElementChanged(e);
    
                if (Control == null)
                {
                    fab = new FloatingActionButton(Xamarin.Forms.Forms.Context);
                    fab.LayoutParameters = new LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                    fab.Clickable = true;
                    fab.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.icon));
                    SetNativeControl(fab);
                }
    
                if (e.NewElement != null)
                {
                    fab.Click += Fab_Click;
                }
    
                if (e.OldElement != null)
                {
                    fab.Click -= Fab_Click;
                }
            }
    
            private void Fab_Click(object sender, EventArgs e)
            {
            }
        }
    }
