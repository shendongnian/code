    [assembly: ExportRenderer(typeof(MainPage), typeof(BottomTabbedPageRenderer))]
    namespace Daddy.Droid
    {
        public class BottomTabbedPageRenderer : TabbedPageRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement == null || e.OldElement != null)
                    return;
    
                TabLayout tablayout = (TabLayout)ViewGroup.GetChildAt(1);
                Android.Views.ViewGroup vgroup = (Android.Views.ViewGroup)tablayout.GetChildAt(0);
                for (int i = 0; i < vgroup.ChildCount; i++)
                {
                    Android.Views.ViewGroup vvgroup = (Android.Views.ViewGroup)vgroup.GetChildAt(i);
                    Typeface fontFace = Typeface.CreateFromAsset(this.Context.Assets, "IranSans.ttf");
                    for (int j = 0; j < vvgroup.ChildCount; j++)
                    {
                        Android.Views.View vView = (Android.Views.View)vvgroup.GetChildAt(j);
                        if (vView.GetType() == typeof(Android.Support.V7.Widget.AppCompatTextView) || vView.GetType() == typeof(Android.Widget.TextView))
                        {
    						//here change textview style
                            TextView txtView = (TextView)vView;                        
                            txtView.TextSize = 14f;
                            txtView.SetTypeface(fontFace, TypefaceStyle.Normal);
                        }
                    }
                }
            }
        }
    }
