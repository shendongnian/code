    [assembly: ExportRenderer(typeof(Entry), typeof(MyEntryRenderer))]
    namespace YourNameSpace
    {
        public class MyEntryRenderer : EntryRenderer
        {
            public MyEntryRenderer(Context context) : base(context) { }
    
            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);
    
                if (Control == null || e.NewElement == null) return;
    
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.White);
                else
                    Control.Background.SetColorFilter(Android.Graphics.Color.White, PorterDuff.Mode.SrcAtop);
            }
        }
    }
