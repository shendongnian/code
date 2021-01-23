    public class MyMasterDetailPageRenderer : Xamarin.Forms.Platform.Android.AppCompat.MasterDetailPageRenderer
    {
        public override bool OnTouchEvent(MotionEvent e)
        {
            if (IsDrawerOpen(Android.Support.V4.View.GravityCompat.Start))
                return base.OnTouchEvent(e);
            else
            {
                if (e.Action == MotionEventActions.Up || e.Action == MotionEventActions.Down)
                    return base.OnTouchEvent(e);
                return true;
            }
        }
    }
